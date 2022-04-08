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
//     Nombre: EntityFrameworkRepository.Async.cs
//     Fecha creación: 2021/10/26 at 09:06 AM
//     Fecha modificación: 2021/10/26 at 09:07 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReporteriaMovistar.Infrastructure.Data.Repositories
{
	public partial class EntityFrameworkRepository<T>
	{
		#region IRepository<T> Members

		public async Task AddAsync(T entity)
		{
			await this.objectSet.AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			await this.objectSet.AddRangeAsync(entities);
		}

		public async Task<T> FindAsync<TType>(TType id)
		{
			return await this.objectSet.FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await this.objectSet.ToListAsync();
		}

		#endregion

		/*public void Remove(T entity)
		{
			this.objectSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			this.objectSet.RemoveRange(entities);
		}*/
	}
}