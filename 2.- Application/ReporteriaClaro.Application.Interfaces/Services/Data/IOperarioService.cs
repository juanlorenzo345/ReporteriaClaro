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
//     Nombre: IOperarioService.cs
//     Fecha creación: 2021/11/17 at 11:13 AM
//     Fecha modificación: 2021/11/17 at 11:13 AM
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
	public interface IOperarioService
	{
		public Task<Result> CrearOperarioAsync(NewOperarioModel modelo);

		public Task<Result> ModificarOperarioAsync(UpdateOperarioModel modelo);

		public Task<Result> EliminarOperarioAsync(DeleteModelBase<int> modelo);

		public Task<Result<OperarioEntityDto>> ObtenerOperarioPorIdAsync(int id);
		
		public Task<Result<IEnumerable<OperarioEntityDto>>> ObtenerListaOperariosAsync(string operario);

		public Task<Result<PagedResult<OperarioEntityDto>>> ObtenerListaOperariosPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}