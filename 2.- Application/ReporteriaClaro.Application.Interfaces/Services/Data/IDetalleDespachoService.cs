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
//     Nombre: IDetalleDespachoService.cs
//     Fecha creación: 2021/11/11 at 03:30 PM
//     Fecha modificación: 2021/11/11 at 03:30 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Threading.Tasks;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;

namespace ReporteriaClaro.Application.Interfaces.Services.Data
{
	public interface IDetalleDespachoService
	{
		public Task<Result> CrearDetalleAsync(NewDetalleDespachoModel modelo);

		public Task<Result> ModificarDetalleAsync(UpdateDetalleDespachoModel modelo);

		public Task<Result> EliminarDetalleAsync(DeleteModelBase<int> modelo);

		public Task<Result<DespachoDetalleEntityDto>> ObtenerDetallePorIdAsync(int id);

		public Task<Result<PagedResult<DespachoDetalleEntityDto>>> ObtenerListaDetallesPaginadoAsync(int idEncabezadoDespacho, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}