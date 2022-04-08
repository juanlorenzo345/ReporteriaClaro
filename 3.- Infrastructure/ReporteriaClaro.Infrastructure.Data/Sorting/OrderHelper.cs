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
// Solución/Proyecto: TsaDotNet / TsaDotNet.Infrastructure.Data
// Info archivo:
//     Nombre: Ordering.cs
//     Fecha creación: 2021/09/23 at 12:58 PM
//     Fecha modificación: 2021/09/23 at 12:58 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Linq;
using System.Linq.Expressions;

namespace ReporteriaClaro.Infrastructure.Data.Sorting
{
	public class OrderHelper<T>
	{
		#region Fields

		private readonly Func<IQueryable<T>, IOrderedQueryable<T>> transform;

		#endregion

		#region Constructors

		private OrderHelper(Func<IQueryable<T>, IOrderedQueryable<T>> transform)
		{
			this.transform = transform;
		}

		#endregion

		#region Methods

		public static OrderHelper<T> OrderByAsc<TKey>(Expression<Func<T, TKey>> primary)
		{
			return new OrderHelper<T>(query => query.OrderBy(primary));
		}

		public static OrderHelper<T> OrderByDesc<TKey>(Expression<Func<T, TKey>> primary)
		{
			return new OrderHelper<T>(query => query.OrderByDescending(primary));
		}

		public IOrderedQueryable<T> Apply(IQueryable<T> query)
		{
			return this.transform(query);
		}

		public OrderHelper<T> ThenByAsc<TKey>(Expression<Func<T, TKey>> secondary)
		{
			return new OrderHelper<T>(query => this.transform(query).ThenBy(secondary));
		}

		public OrderHelper<T> ThenByDesc<TKey>(Expression<Func<T, TKey>> secondary)
		{
			return new OrderHelper<T>(query => this.transform(query).ThenByDescending(secondary));
		}

		#endregion
	}
}