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
//     Nombre: CustomSortingExtensions.cs
//     Fecha creación: 2021/11/04 at 12:22 PM
//     Fecha modificación: 2021/11/04 at 12:22 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Linq;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Domain.Models.Sorting;

namespace ReporteriaClaro.Infrastructure.Data.Extensions
{
	internal static class CustomSortingExtensions
	{
		internal static IQueryable<PronosticoEntity> SortPeriodoBy(this IQueryable<PronosticoEntity> query, SortingDirection direction)
		{
			return direction switch
			{
				SortingDirection.Descending => query.OrderByDescending(e => e.Ano).ThenByDescending(e => e.Mes),
				_ => query.OrderBy(e => e.Ano).ThenBy(e => e.Mes)
			};
		}
	}
}