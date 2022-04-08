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
//     Nombre: ApplicationCookieAuthenticationEvents.cs
//     Fecha creación: 2021/11/02 at 06:20 PM
//     Fecha modificación: 2021/11/02 at 06:20 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Models;

namespace ReporteriaMovistar.Clients.BlazorServerSide.IdentityData
{
	public class ApplicationCookieAuthenticationEvents : CookieAuthenticationEvents
	{
		public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
		{
			if (context is null)
			{
				throw new System.ArgumentNullException(nameof(context));
			}

			string userId = context.Principal?.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

			if (userId == null)
			{
				context.RejectPrincipal();
				await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			}

			// Get an instance using DI
			ApplicationDbContext dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
			ApplicationUser user = await dbContext.Users.FindAsync(userId);
			if (user is null || !user.Active)
			{
				context.RejectPrincipal();
				await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			}

			/*var userPrincipal = context.Principal;

			// Look for the LastChanged claim.
			var lastChanged = (from c in userPrincipal.Claims
			where c.Type == "LastChanged"
			select c.Value).FirstOrDefault();

			if (string.IsNullOrEmpty(lastChanged) ||
			!_userRepository.ValidateLastChanged(lastChanged))
			{
				context.RejectPrincipal();

				await context.HttpContext.SignOutAsync(
				CookieAuthenticationDefaults.AuthenticationScheme);
			}*/
		}

		/*public static async Task ValidateAsync(CookieValidatePrincipalContext context)
		{
			if (context is null)
			{
				throw new System.ArgumentNullException(nameof(context));
			}

			string userId = context.Principal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
			
			if (userId == null)
			{
				context.RejectPrincipal();
				return;
			}

			// Get an instance using DI
			ApplicationDbContext dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
			ApplicationUser user = await dbContext.Users.FindAsync(userId);
			if (user is null)
			{
				context.RejectPrincipal();
				return;
			}
		}*/
	}
}