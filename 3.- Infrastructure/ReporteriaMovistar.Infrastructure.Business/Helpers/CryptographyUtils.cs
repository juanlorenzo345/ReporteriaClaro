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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Infrastructure.Business
// Info archivo:
//     Nombre: CryptographyUtils.cs
//     Fecha creación: 2021/10/25 at 09:08 AM
//     Fecha modificación: 2021/10/25 at 09:09 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Security.Cryptography;
using SecurityDriven.Inferno;
using SecurityDriven.Inferno.Extensions;

namespace ReporteriaMovistar.Infrastructure.Business.Helpers
{
	public static class CryptographyUtils
	{
		#region Methods

		public static string HashPassword(string password)
		{
			byte[] data = Utils.SafeUTF8.GetBytes(password);
			using (HMAC hmac = SuiteB.HmacFactory()) // HMACSHA384
			{
				hmac.Key = new byte[] { 1, 2, 3, 4, 5 };
				return hmac.ComputeHash(data).ToB64();
			}
		}

		public static bool ValidatePassword(string password, string hash)
		{
			return HashPassword(password) == hash;
		}

		internal static string GenerateApiKey()
		{
			byte[] bytes = new CryptoRandom().NextBytes(64);
			return bytes.ToB64();
		}

		internal static string HashApiKey(string key)
		{
			byte[] data = Utils.SafeUTF8.GetBytes(key);
			using (HMAC hmac = SuiteB.HmacFactory()) // HMACSHA384
			{
				hmac.Key = new byte[] { 52, 8, 37, 15, 97 };
				return hmac.ComputeHash(data).ToB64();
			}
		}

		#endregion
	}
}