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
//     Nombre: IPronosticoService.cs
//     Fecha creación: 2021/10/29 at 06:06 PM
//     Fecha modificación: 2021/10/29 at 06:06 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Threading.Tasks;
using ReporteriaMovistar.Application.Models.Input.Delete;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Pagination;
using ReporteriaMovistar.Application.Models.Sorting;
using ReporteriaMovistar.Application.Models.Transfer;

namespace ReporteriaMovistar.Application.Interfaces.Services.Data
{
	public interface IPronosticoService
	{
		public Task<Result> CrearPronosticoAsync(NewPronosticoModel modelo);

		public Task<Result> ModificarPronosticoAsync(UpdatePronosticoModel modelo);

		public Task<Result> EliminarPronosticoAsync(DeleteModelBase<int> modelo);

		public Task<Result<PronosticoEntityDto>> ObtenerPronosticoPorIdAsync(int id);

		public Task<Result<PagedResult<PronosticoEntityDto>>> ObtenerListaPronosticosPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}