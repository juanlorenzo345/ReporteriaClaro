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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Clients.BlazorServerSide
// Info archivo:
//     Nombre: ApplicationPasswordHasher.cs
//     Fecha creación: 2021/10/25 at 10:26 AM
//     Fecha modificación: 2021/10/25 at 11:47 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.AspNetCore.Identity;
using ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Models;
using ReporteriaClaro.Infrastructure.Business.Helpers;

namespace ReporteriaClaro.Clients.BlazorServerSide.IdentityData
{
	public class ApplicationPasswordHasher : IPasswordHasher<ApplicationUser>
	{
		#region IPasswordHasher<ApplicationUser> Members

		public string HashPassword(ApplicationUser user, string password)
		{
			return CryptographyUtils.HashPassword(password);
		}

		public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
		{
			if (hashedPassword == HashPassword(user, providedPassword))
			{
				return PasswordVerificationResult.Success;
			}

			return PasswordVerificationResult.Failed;
		}

		#endregion
	}
}