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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Application.Interfaces
// Info archivo:
//     Nombre: ICargaMasivaService.cs
//     Fecha creación: 2021/11/18 at 12:58 PM
//     Fecha modificación: 2021/11/18 at 12:58 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.IO;
using System.Threading.Tasks;
using ReporteriaMovistar.Application.Models.Output;

namespace ReporteriaMovistar.Application.Interfaces.Services.File
{
	public interface ICargaMasivaService
	{
		public Task<Result> ImportarArchivoAsync(Stream archivo, DateTime fecha, string usuario);

		public Task<Result<FileResult>> ExportarEjemploAsync();
	}
}