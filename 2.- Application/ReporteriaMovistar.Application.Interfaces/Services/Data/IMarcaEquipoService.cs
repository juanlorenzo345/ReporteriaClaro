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
//     Nombre: IMarcaEqupoService.cs
//     Fecha creación: 2021/10/29 at 06:02 PM
//     Fecha modificación: 2021/10/29 at 06:02 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using ReporteriaMovistar.Application.Models.Input.Delete;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Pagination;
using ReporteriaMovistar.Application.Models.Sorting;
using ReporteriaMovistar.Application.Models.Transfer;
using System.Threading.Tasks;

namespace ReporteriaMovistar.Application.Interfaces.Services.Data
{
	public interface IMarcaEquipoService
	{
		public Task<Result> CrearMarcaAsync(NewMarcaEquipoModel modelo);

		public Task<Result> ModificarMarcaAsync(UpdateMarcaEquipoModel modelo);

		public Task<Result> EliminarMarcaEquipoAsync(DeleteModelBase<int> modelo);

		public Task<Result<EquipoMarcaEntityDto>> ObtenerMarcaPorIdAsync(int id);

		public Task<Result<IEnumerable<EquipoMarcaEntityDto>>> ObtenerListaMarcasAsync(string marca);

		public Task<Result<PagedResult<EquipoMarcaEntityDto>>> ObtenerListaMarcasPaginadosAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}