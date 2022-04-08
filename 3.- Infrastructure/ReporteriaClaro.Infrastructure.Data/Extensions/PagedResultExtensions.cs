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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Infrastructure.Data
// Info archivo:
//     Nombre: PagedResultExtensions.cs
//     Fecha creación: 2021/10/25 at 08:52 AM
//     Fecha modificación: 2021/10/25 at 08:53 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Domain.Models.Pagination;

namespace ReporteriaClaro.Infrastructure.Data.Extensions
{
	internal static class PagedResultExtensions
	{
		#region Methods

		internal static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int pageSize) where T : class
		{
			//HACK: MudTable manda la página en base 0 en vez de base 1, por ello es necesario hacer este ajuste.
			++page;

			PagedResult<T> result = new PagedResult<T>();
			result.CurrentPage = page;
			result.PageSize = pageSize;
			result.RowCount = query.Count();

			double pageCount = (double)result.RowCount / pageSize;
			result.PageCount = (int)Math.Ceiling(pageCount);

			int skip = (page - 1) * pageSize;
			result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

			return result;
		}

		#endregion
	}
}