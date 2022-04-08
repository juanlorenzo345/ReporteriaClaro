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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Infrastructure.Business
// Info archivo:
//     Nombre: PagedResultsExtensions.cs
//     Fecha creación: 2021/10/25 at 08:51 AM
//     Fecha modificación: 2021/10/25 at 08:56 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;

namespace ReporteriaMovistar.Infrastructure.Business.Extensions
{
	internal static class PagedResultsExtensions
	{
		#region Methods

		internal static Application.Models.Pagination.PagedResult<TDto> ToPagedDto<TEntity, TDto>(this Domain.Models.Pagination.PagedResult<TEntity> results, IList<TDto> entitiesToDto) where TEntity : class where TDto : class
		{
			return new Application.Models.Pagination.PagedResult<TDto>()
			{
				CurrentPage = results.CurrentPage,
				PageSize = results.PageSize,
				RowCount = results.RowCount,
				PageCount = results.PageCount,
				Results = entitiesToDto
			};
		}

		#endregion
	}
}