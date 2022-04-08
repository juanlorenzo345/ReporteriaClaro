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
//     Nombre: IDespachoService.cs
//     Fecha creación: 2021/11/11 at 01:22 PM
//     Fecha modificación: 2021/11/11 at 01:23 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Threading.Tasks;
using ReporteriaClaro.Application.Interfaces.Services.File;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;

namespace ReporteriaClaro.Application.Interfaces.Services.Data
{
	public interface IEncabezadoDespachoService : ICargaMasivaService
	{
		public Task<Result<int>> CrearEncabezadoAsync(NewEncabezadoDespachoModel modelo);

		public Task<Result> ModificarEncabezadoAsync(UpdateEncabezadoDespachoModel modelo);

		public Task<Result> EliminarEncabezadoAsync(DeleteModelBase<int> modelo);

		public Task<Result<DespachoEncabezadoEntityDto>> ObtenerEncabezadoPorIdAsync(int id);

		public Task<Result<PagedResult<DespachoEncabezadoEntityDto>>> ObtenerListaEncabezadosPaginadoAsync(string guia, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}