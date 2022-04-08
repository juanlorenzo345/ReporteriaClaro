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
//     Nombre: FileExtensions.cs
//     Fecha creación: 2021/10/25 at 08:50 AM
//     Fecha modificación: 2021/10/25 at 08:50 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaMovistar.Infrastructure.Business.File
{
	public static class FileExtensions
	{
		#region Fields

		/// <summary>
		/// Obtiene la extensión del archivo de valores separados por coma (CSV).
		/// </summary>
		public const string Csv = "csv";

		/// <summary>
		/// Obtiene la extensión del archivo de Excel 2007 o superior sin macros.
		/// </summary>
		public const string ExcelSinMacros2007 = "xlsx";

		/// <summary>
		/// Obtiene la extensión del archivo Json.
		/// </summary>
		public const string Json = "json";

		#endregion
	}
}