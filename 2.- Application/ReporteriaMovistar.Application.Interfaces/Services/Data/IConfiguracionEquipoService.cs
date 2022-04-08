﻿#region Header
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
//     Nombre: IConfiguracionEquipoService.cs
//     Fecha creación: 2021/11/08 at 01:28 PM
//     Fecha modificación: 2021/11/08 at 01:28 PM
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
	public interface IConfiguracionEquipoService
	{
		public Task<Result> CrearConfiguracionAsync(NewConfiguracionEquipoModel modelo);

		public Task<Result> ModificarConfiguracionAsync(UpdateConfiguracionEquipoModel modelo);

		public Task<Result> EliminarConfiguracionAsync(DeleteModelBase<int> modelo);

		public Task<Result<EquipoConfiguracionEntityDto>> ObtenerConfiguracionPorIdAsync(int id);

		public Task<Result<PagedResult<EquipoConfiguracionEntityDto>>> ObtenerListaConfiguracionesPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);
	}
}