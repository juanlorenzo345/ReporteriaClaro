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
//     Nombre: IEstadoGuiaService.cs
//     Fecha creación: 2021/10/29 at 06:07 PM
//     Fecha modificación: 2021/10/29 at 06:07 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;
using System.Threading.Tasks;

namespace ReporteriaClaro.Application.Interfaces.Services.Data
{
	public interface IEstadoDespachoService
	{
		public Task<Result> CrearEstadoAsync(NewEstadoDespachoModel modelo);

		public Task<Result> ModificarEstadoAsync(UpdateEstadoDespachoModel modelo);

		public Task<Result> EliminarEstadoAsync(DeleteModelBase<int> modelo);

		public Task<Result<DespachoEstadoEntityDto>> ObtenerEstadoPorIdAsync(int id);

		public Task<Result<IEnumerable<DespachoEstadoEntityDto>>> ObtenerListaEstadosAsync();

		public Task<Result<PagedResult<DespachoEstadoEntityDto>>> ObtenerListaEstadosPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}