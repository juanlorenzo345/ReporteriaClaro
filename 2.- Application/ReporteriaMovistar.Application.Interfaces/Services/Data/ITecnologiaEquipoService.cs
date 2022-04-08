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
//     Nombre: ITecnologiaEquipoService.cs
//     Fecha creación: 2021/10/29 at 06:03 PM
//     Fecha modificación: 2021/10/29 at 06:03 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
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
	public interface ITecnologiaEquipoService
	{
		public Task<Result> CrearTecnologiaAsync(NewTecnologiaEquipoModel modelo);

		public Task<Result> ModificarTecnologiaAsync(UpdateTecnologiaEquipoModel modelo);

		public Task<Result> EliminarTecnologiaAsync(DeleteModelBase<int> modelo);

		public Task<Result<EquipoTecnologiaEntityDto>> ObtenerTecnologiaPorIdAsync(int id);

		public Task<Result<IEnumerable<EquipoTecnologiaEntityDto>>> ObtenerListaTecnologiasAsync();

		public Task<Result<PagedResult<EquipoTecnologiaEntityDto>>> ObtenerListaTecnologiasPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}