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
//     Nombre: ExcelFileHandlerExtensions.cs
//     Fecha creación: 2021/10/25 at 08:56 AM
//     Fecha modificación: 2021/10/25 at 08:56 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using OfficeOpenXml;
using ReporteriaMovistar.Infrastructure.Business.Excel;

namespace ReporteriaMovistar.Infrastructure.Business.Extensions
{
	internal static class ExcelFileHandlerExtensions
	{
		#region Methods

		internal static ExcelFileHandler CreateWorsheets(this ExcelFileHandler excelFileHandler, params string[] worksheetNames)
		{
			foreach (string worksheetName in worksheetNames)
			{
				if (string.IsNullOrEmpty(worksheetName))
				{
					throw new ArgumentException("El nombre de la hoja no puede ser null o vacío.");
				}

				excelFileHandler.ExcelFile.Workbook.Worksheets.Add(worksheetName);
			}

			return excelFileHandler;
		}

		internal static ExcelFileHandler SetWorkbookFormat(this ExcelFileHandler excelFileHandler, Action<ExcelWorkbook> predicate = null)
		{
			

			return excelFileHandler;
		}

		#endregion
	}
}