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
//     Nombre: IEstadoComponenteService.cs
//     Fecha creación: 2021/11/11 at 10:42 AM
//     Fecha modificación: 2021/11/11 at 10:42 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
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
	public interface IEstadoComponenteService
	{
		public Task<Result> CrearEstadoAsync(NewEstadoComponenteModel modelo);

		public Task<Result> ModificarEstadoAsync(UpdateEstadoComponenteModel modelo);

		public Task<Result> EliminarEstadoAsync(DeleteModelBase<int> modelo);

		public Task<Result<ComponenteEstadoEntityDto>> ObtenerEstadoPorIdAsync(int id);

		public Task<Result<IEnumerable<ComponenteEstadoEntityDto>>> ObtenerListaEstadosAsync();

		public Task<Result<PagedResult<ComponenteEstadoEntityDto>>> ObtenerListaEstadosPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}