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
//     Nombre: FileHelper.cs
//     Fecha creación: 2021/11/19 at 02:43 PM
//     Fecha modificación: 2021/11/19 at 02:43 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Helpers
{
	internal static class FileHelper
	{
		#region Fields

		// NOTE: Se obtuvo de aquí https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc

		/// <summary>
		/// Obtiene una lista con los tamaños de sufijos.
		/// </summary>
		private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

		#endregion

		#region Methods

		/// <summary>
		/// Realiza la conversión de megabytes a bytes.
		/// </summary>
		/// <param name="megabytes">Valor (en megabytes).</param>
		/// <returns>Devuelve el valor en bytes.</returns>
		internal static long ConvertMegabytesToBytes(double megabytes)
		{
			return Convert.ToInt64(megabytes * 1024 * 1024);
		}

		/// <summary>
		/// Obtiene el tamaño del archivo con sufijo.
		/// </summary>
		/// <param name="tamano">Tamaño (en bytes).</param>
		/// <param name="cantidadDecimales">Cantidad de decimales (opcional).</param>
		/// <returns>Devuelve el tamaño del archivo con su respectivo sufijo.</returns>
		internal static string SizeWithSuffix(long tamano, int cantidadDecimales = 1)
		{
			if (cantidadDecimales < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(cantidadDecimales));
			}

			switch (tamano)
			{
				case < 0:
					return "-" + SizeWithSuffix(-tamano, cantidadDecimales);
				case 0:
					return string.Format($"{{0:N{cantidadDecimales}}} {{1}}", 0, SizeSuffixes[0]);
			}

			// mag is 0 for bytes, 1 for KB, 2, for MB, etc.
			int mag = (int)Math.Log(tamano, 1024);

			// 1L << (mag * 10) == 2 ^ (10 * mag) 
			// [i.e. the number of bytes in the unit corresponding to mag]
			decimal tamanoAjustado = (decimal)tamano / (1L << (mag * 10));

			// make adjustment when the value is large enough that
			// it would round up to 1000 or more
			if (Math.Round(tamanoAjustado, cantidadDecimales) >= 1000)
			{
				mag += 1;
				tamanoAjustado /= 1024;
			}

			return string.Format($"{{0:N{cantidadDecimales}}} {{1}}", tamanoAjustado, SizeSuffixes[mag]);
		}

		#endregion
	}
}