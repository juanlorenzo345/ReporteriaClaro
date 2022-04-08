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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Application.Interfaces
// Info archivo:
//     Nombre: IEquipoService.cs
//     Fecha creación: 2021/11/08 at 01:19 PM
//     Fecha modificación: 2021/11/08 at 01:19 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;

namespace ReporteriaClaro.Application.Interfaces.Services.Data
{
	public interface IEquipoService
	{
		public Task<Result<(int equiposComparados, int equiposInsertados, int equiposActualizados, DateTime
		fechaInicioRecepcion, DateTime fechaTerminoRecepcion)>> EjecutarMergeEquipoFullstarAsync(DateTime fecha,
		string usuario);

		public Task<Result<IEnumerable<SPInformacionEquipoEntityResultDto>>> ObtenerListaEquiposAsync(string esn);

		public Task<Result<PagedResult<EquipoEntityDto>>> ObtenerListaEquiposPaginadoAsync(string esn, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}