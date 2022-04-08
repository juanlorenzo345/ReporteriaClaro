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
//     Nombre: EntityFrameworkRepository.Bulk.cs
//     Fecha creación: 2021/10/26 at 09:06 AM
//     Fecha modificación: 2021/10/26 at 09:07 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;

namespace ReporteriaClaro.Infrastructure.Data.Repositories
{
	public partial class EntityFrameworkRepository<T>
	{
		#region IRepository<T> Members

		public async Task BulkDeleteAsync(IList<T> entities)
		{
			BulkConfig configuration = new BulkConfig()
			{
				BatchSize = entities.Count
			};

			if (entities.Count > 0)
			{
				await this.Context.BulkDeleteAsync<T>(entities, configuration);
			}
		}

		public async Task BulkInsertAsync(IList<T> entities)
		{
			BulkConfig configuration = new BulkConfig()
			{
				BatchSize = entities.Count
			};

			if (entities.Count > 0)
			{
				await this.Context.BulkInsertAsync<T>(entities, configuration);
			}
		}

		public async Task BulkUpdateAsync(IList<T> entities)
		{
			BulkConfig configuration = new BulkConfig()
			{
				BatchSize = entities.Count
			};

			if (entities.Count > 0)
			{
				await this.Context.BulkUpdateAsync<T>(entities, configuration);
			}
		}

		#endregion
	}
}