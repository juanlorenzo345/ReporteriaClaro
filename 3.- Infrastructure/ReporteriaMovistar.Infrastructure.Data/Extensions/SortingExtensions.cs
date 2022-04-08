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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Infrastructure.Data
// Info archivo:
//     Nombre: SortingExtensions.cs
//     Fecha creación: 2021/10/29 at 04:56 PM
//     Fecha modificación: 2021/10/29 at 04:56 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Linq;
using System.Linq.Expressions;
using ReporteriaMovistar.Domain.Models.Sorting;

namespace ReporteriaMovistar.Infrastructure.Data.Extensions
{
	internal static class SortingExtensions
	{
		internal static IQueryable<T> SortBy<T, TKey>(this IQueryable<T> query, SortingDirection direction, Expression<Func<T, TKey>> column)
		{
			return direction switch
			{
				SortingDirection.Descending => query.OrderByDescending(column),
				_ => query.OrderBy(column)
			};
		}
	}
}