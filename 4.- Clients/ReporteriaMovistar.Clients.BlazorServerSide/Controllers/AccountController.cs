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
//     Nombre: AccountController.cs
//     Fecha creación: 2021/11/15 at 10:21 AM
//     Fecha modificación: 2021/11/15 at 10:22 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Models;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Controllers
{
	[Route("account")]
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;

		private readonly SignInManager<ApplicationUser> signInManager;

		private readonly IDataProtector dataProtector;

		public AccountController(IDataProtectionProvider dataProtectionProvider, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			this.dataProtector = dataProtectionProvider.CreateProtector("SignIn");
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet("signinactual")]
		public async Task<IActionResult> SignInActual(string t)
		{
			string data = this.dataProtector.Unprotect(t);
			string[] parts = data.Split('|');
			ApplicationUser user = await this.userManager.FindByIdAsync(parts[0]);
			bool isTokenValid = await this.userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, "SignIn", parts[1]);

			if (!isTokenValid)
			{
				return Unauthorized("Usuario no autorizado.");
			}

			await this.signInManager.SignInAsync(user, bool.Parse(parts[2]));
			if (parts.Length == 4 && Url.IsLocalUrl(parts[3]))
			{
				return Redirect(parts[3]);
			}

			return Redirect("/");
		}

		[Authorize]
		[HttpGet("logout")]
		public async Task<IActionResult> SignOut()
		{
			await this.signInManager.SignOutAsync();
			return Redirect(PageRoutes.Login);
		}
    }
}