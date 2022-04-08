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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Domain.Interfaces
// Info archivo:
//     Nombre: IRepository.Async.cs
//     Fecha creación: 2021/10/26 at 09:04 AM
//     Fecha modificación: 2021/10/26 at 09:05 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReporteriaClaro.Domain.Interfaces.Repositories
{
	public partial interface IRepository<T>
	{
		#region Methods

		/// <summary>
		/// Añade una entidad al repositorio asincrónicamente.
		/// </summary>
		/// <param name="entity">Entidad.</param>
		public Task AddAsync(T entity);

		/// <summary>
		/// Añade una colección de entidades al repositorio asincrónicamente.
		/// </summary>
		/// <param name="entities">Entidades.</param>
		public Task AddRangeAsync(IEnumerable<T> entities);

		/// <summary>
		/// Busca una entidad según su ID asincrónicamente.
		/// </summary>
		/// <param name="id">ID de la entidad.</param>
		/// <returns>Devuelve un <see cref="TEntity"/> que representa la entidad buscada.</returns>
		public Task<T> FindAsync<TType>(TType id);

		/// <summary>
		/// Obtiene la colección de entidades asincrónicamente.
		/// </summary>
		/// <returns>Devuelve una colección de <see cref="TEntity"/> que representa las entidades buscadas.</returns>
		public Task<IEnumerable<T>> GetAllAsync();

		#endregion

		/// <summary>
		/// Elimina una entidad asincrónicamente.
		/// </summary>
		/// <param name="entity">Entidad a eliminar.</param>
		//public Task RemoveAsync(T entity);

		/// <summary>
		/// Elimina una colección de entidades asincrónicamente.
		/// </summary>
		/// <param name="entities">Entidades a eliminar.</param>
		//public Task RemoveRangeAsync(IEnumerable<T> entities);
	}
}