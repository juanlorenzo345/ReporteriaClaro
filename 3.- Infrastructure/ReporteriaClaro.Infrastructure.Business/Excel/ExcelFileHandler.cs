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
//     Nombre: ExcelFileHandler.cs
//     Fecha creación: 2021/10/25 at 08:55 AM
//     Fecha modificación: 2021/10/25 at 08:57 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.IO;
using OfficeOpenXml;
using ReporteriaClaro.Infrastructure.Business.File;
using ReporteriaClaro.Infrastructure.Business.Helpers;

namespace ReporteriaClaro.Infrastructure.Business.Excel
{
	internal class ExcelFileHandler : IDisposable
	{
		#region Fields

		private readonly string fileName;

		private bool disposed = false;

		private FileInfo fileInfo;

		#endregion

		#region Constructors

		internal ExcelFileHandler() : this(Guid.NewGuid() + FileExtensions.ExcelSinMacros2007)
		{

		}

		internal ExcelFileHandler(string fileName)
		{
			ExcelPackage.LicenseContext = LicenseContext.Commercial;
			this.fileName = fileName;
			SetFileInfo();
			this.ExcelFile = new ExcelPackage(this.fileInfo);
		}

		#endregion

		#region IDisposable Members

		public void Dispose() => Dispose(true);

		#endregion

		#region Properties and Indexers

		internal ExcelPackage ExcelFile
		{
			get;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Crea las hojas del libro.
		/// </summary>
		/// <param name="worksheetNames">Nombre de las hojas.</param>
		internal void CreateWorksheets(params string[] worksheetNames)
		{
			foreach (string worksheetName in worksheetNames)
			{
				if (string.IsNullOrEmpty(worksheetName))
				{
					throw new ArgumentException("El nombre de la hoja no puede ser null o vacío.");
				}

				this.ExcelFile.Workbook.Worksheets.Add(worksheetName);
			}
		}

		/// <summary>
		/// Especifica el formato general a aplicar en el libro (estilo, diseño, entre otros).
		/// </summary>
		internal void SetDefaultFormatWorkbook()
		{
			foreach (ExcelWorksheet worksheet in this.ExcelFile.Workbook.Worksheets)
			{
				worksheet.PrinterSettings.ShowGridLines = false;
				worksheet.View.ShowGridLines = false;
				worksheet.Cells.Style.Font.Name = "Arial";
				worksheet.Cells.Style.Font.Size = 11;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}

			if (disposing)
			{
				this.ExcelFile.Workbook.Dispose();
				this.ExcelFile.Dispose();

				if (this.fileInfo.Exists)
				{
					this.fileInfo.Delete();
				}
			}
		}

		/// <summary>
		/// Establece la información del archivo.
		/// </summary>
		private void SetFileInfo()
		{
			this.fileInfo = new FileInfo(Path.GetTempPath() + this.fileName);

			if (this.fileInfo.Exists)
			{
				this.fileInfo.Delete();
			}
		}

		#endregion
	}
}