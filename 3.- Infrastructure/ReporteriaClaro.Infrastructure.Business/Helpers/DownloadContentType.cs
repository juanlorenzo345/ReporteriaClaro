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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Infrastructure.Business
// Info archivo:
//     Nombre: DownloadContentType.cs
//     Fecha creación: 2021/11/19 at 03:04 PM
//     Fecha modificación: 2021/11/19 at 03:04 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Infrastructure.Business.Helpers
{
	public static class DownloadContentType
	{
		/// <summary>
		/// Obtiene el comando para especificar el tipo de contenido como libro de Excel.
		/// </summary>
		public const string ExcelWorkbook = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

		/// <summary>
		/// Obtiene el comando para especificar el tipo de contenido como archivo CSV.
		/// </summary>
		public const string Csv = "application/csv";
	}
}