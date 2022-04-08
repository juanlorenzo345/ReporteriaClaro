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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Tasks.ApiUtilities
// Info archivo:
//     Nombre: CryptographyUtils.cs
//     Fecha creación: 2021/11/26 at 12:49 PM
//     Fecha modificación: 2021/11/26 at 12:49 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Security.Cryptography;
using SecurityDriven.Inferno;
using SecurityDriven.Inferno.Extensions;

namespace ReporteriaClaro.Tasks.ApiUtilities.Helpers
{
	internal static class CryptographyUtils
	{
		internal static string Hash(string value)
		{
			byte[] data = Utils.SafeUTF8.GetBytes(value);
			using (HMAC hmac = SuiteB.HmacFactory()) // HMACSHA384
			{
				hmac.Key = new byte[] { 52, 8, 37, 15, 97 };
				return hmac.ComputeHash(data).ToB64();
			}
		}

		internal static string GenerateApiKey()
		{
			byte[] bytes = new CryptoRandom().NextBytes(64);
			return bytes.ToB64();
		}
	}
}