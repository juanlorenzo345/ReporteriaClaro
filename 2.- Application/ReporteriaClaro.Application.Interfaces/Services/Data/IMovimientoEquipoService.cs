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
//     Nombre: IMovimientoEquipoService.cs
//     Fecha creación: 2021/11/09 at 10:43 AM
//     Fecha modificación: 2021/11/09 at 10:43 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using ReporteriaClaro.Application.Models.Enums;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;

namespace ReporteriaClaro.Application.Interfaces.Services.Data
{
	public interface IMovimientoEquipoService
	{
		//public Task<Result> CrearMovimientoAsync(NewMovimientoEquipoModel modelo);

		public Task<Result> CrearMovimientoBulkAsync(NewBulkMovimientoEquipoModel modelo);

		public Task<Result> EliminarMovimientoAsync(DeleteModelBase<int> modelo);

		public Task<Result<SPUltimoOperarioEtapaEntityResultDto>> ObtenerUltimoOperarioEtapaAsync(int idEquipo, int idEtapa);

		public Task<Result<SPSeguimientoEquipoEntityResultDto>> ObtenerSeguimientoEquipoAsync(string esn);

		public Task<Result<SPSeguimientoUltimoMovimientoEntityResultDto>> ObtenerSeguimientoUltimoMovimientoAsync(string esn);

		public Task<Result<SPSeguimientoDespachoEntityResultDto>> ObtenerSeguimientoDespachoAsync(string esn);

		public Task<Result<IEnumerable<VWMovimientoEquipoEntityDto>>> ObtenerListaMovimientosPorEsnPaginadoAsync(string esn, bool mostrarEliminados);

		public Task<Result<PagedResult<VWMovimientoEquipoEntityDto>>> ObtenerListaMovimientosPaginadoAsync(string esn, Etapa etapaOrigen, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);

		public Task<Result<PagedResult<VWMovimientoEquipoEntityDto>>> ObtenerListaMovimientosScrapPaginadoAsync(string esn, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}