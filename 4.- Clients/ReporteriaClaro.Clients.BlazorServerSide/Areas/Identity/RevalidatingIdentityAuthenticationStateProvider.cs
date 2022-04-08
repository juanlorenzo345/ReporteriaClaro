using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Models;

namespace ReporteriaClaro.Clients.BlazorServerSide.Areas.Identity
{
    public class RevalidatingIdentityAuthenticationStateProvider<TUser> : RevalidatingServerAuthenticationStateProvider where TUser : class
    {
	    #region Fields

	    private readonly IdentityOptions options;

	    private readonly IServiceScopeFactory scopeFactory;

        #endregion

        #region Constructors

        public RevalidatingIdentityAuthenticationStateProvider(ILoggerFactory loggerFactory, IServiceScopeFactory scopeFactory, IOptions<IdentityOptions> optionsAccessor) : base(loggerFactory)
        {
	        this.scopeFactory = scopeFactory;
	        this.options = optionsAccessor.Value;
        }

        #endregion

        #region Properties and Indexers

        protected override TimeSpan RevalidationInterval => TimeSpan.FromSeconds(30);

		#endregion

        #region Methods

        protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            // Get the user manager from a new scope to ensure it fetches fresh data
            IServiceScope scope = this.scopeFactory.CreateScope();
            try
            {
                UserManager<TUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<TUser>>();
                return (await ValidateSecurityStampAsync(userManager, authenticationState.User) && await ValidateEnabledUserAsync(userManager, authenticationState.User));
            }
            finally
            {
                if (scope is IAsyncDisposable asyncDisposable)
                {
                    await asyncDisposable.DisposeAsync();
                }
                else
                {
                    scope.Dispose();
                }
            }
        }

        private async Task<bool> ValidateEnabledUserAsync(UserManager<TUser> userManager, ClaimsPrincipal principal)
        {
            TUser user = await userManager.GetUserAsync(principal);

            if (user is null)
            {
                return false;
            }

            if (user is ApplicationUser appUser)
            {
                return appUser.Active;
            }

            return true;
        }

        private async Task<bool> ValidateSecurityStampAsync(UserManager<TUser> userManager, ClaimsPrincipal principal)
        {
            TUser user = await userManager.GetUserAsync(principal);

            if (user is null)
            {
                return false;
            }

            if (!userManager.SupportsUserSecurityStamp)
            {
                return true;
            }

            string principalStamp = principal.FindFirstValue(this.options.ClaimsIdentity.SecurityStampClaimType);
            string userStamp = await userManager.GetSecurityStampAsync(user);
            return principalStamp == userStamp;
        }

        #endregion
    }
}
