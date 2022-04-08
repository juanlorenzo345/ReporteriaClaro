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
//     Nombre: ApplicationUserClaimsPrincipalFactory.cs
//     Fecha creación: 2021/10/25 at 09:56 AM
//     Fecha modificación: 2021/10/25 at 10:17 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Models;

namespace ReporteriaMovistar.Clients.BlazorServerSide.IdentityData
{
	/// <summary>
	/// Extiende la clase <see cref="UserClaimsPrincipalFactory{TUser}"/> para añadir custom claims.
	/// </summary>
	public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
	{
		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="ApplicationUserClaimsPrincipalFactory"/> según el user manager, user role y option accessor especificados.
		/// </summary>
		/// <param name="userManager">Administrador de usuario.</param>
		/// <param name="roleManager">Administrador de rol.</param>
		/// <param name="optionsAccessor">Opciones de acceso.</param>
		public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
		{
			
		}

		#endregion

		#region Methods

		/// <summary>
		/// Crea un nuevo claim custom, que incluye el del nombre completo del usuario, asincrónicamente.
		/// </summary>
		/// <param name="user">Usuario.</param>
		/// <returns>Devuelve un <see cref="ClaimsPrincipal"/> que incluye el nombre completo del usuario.</returns>
		public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
		{
			IList<string> roles = await this.UserManager.GetRolesAsync(user);
			ClaimsPrincipal principal = await base.CreateAsync(user);

			if (!string.IsNullOrWhiteSpace(user.FullName))
			{
				//TODO: Agregar la información de negocio y sucursal aquí!
				((ClaimsIdentity)principal.Identity).AddClaims(new[] 
				{
					new Claim("FullName", user.FullName),
				});
			}

			return principal;
		}

		#endregion
	}
}