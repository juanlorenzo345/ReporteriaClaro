#region Header
//  ---------------------------------------------------------------------------------------------------
// |                                                                                                   |
// |             __                         __               __       ______ __     _  __              |
// |            / /   ____   ____ _ __  __ / /_ ___   _____ / /_     / ____// /_   (_)/ /___           |
// |           / /   / __ \ / __ `// / / // __// _ \ / ___// __ \   / /    / __ \ / // // _ \          |
// |          / /___/ /_/ // /_/ // /_/ // /_ /  __// /__ / / / /  / /___ / / / // // //  __/          |
// |         /_____/\____/ \__, / \__, / \__/ \___/ \___//_/ /_/   \____//_/ /_//_//_/ \___/           |
// |                      /____/ /____/                                                                |
// |                                                                                                   |
//  ---------------------------------------------------------------------------------------------------
// 
// Usuario: cristian.ulloa
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Clients.BlazorServerSide
// Info archivo:
//     Nombre: AuthenticationServiceCollectionExtensions.cs
//     Fecha creación: 2021/10/25 at 09:43 AM
//     Fecha modificación: 2021/10/25 at 09:44 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ReporteriaMovistar.Clients.BlazorServerSide.Areas.Identity;
using ReporteriaMovistar.Clients.BlazorServerSide.Data;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Models;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Extensions.ServiceCollectionExtensions
{
	internal static class AuthenticationServiceCollectionExtensions
	{
		#region Methods

		internal static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
		{
			services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredLength = 8;
			}).AddEntityFrameworkStores<ApplicationDbContext>()
			.AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

			services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
			services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
			services.AddScoped<ApplicationCookieAuthenticationEvents>();
			services.AddScoped<IHostEnvironmentAuthenticationStateProvider>(sp =>
			(ServerAuthenticationStateProvider) sp.GetRequiredService<AuthenticationStateProvider>());
			return services;
		}

		#endregion
	}
}