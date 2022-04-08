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
//     Nombre: EntityFrameworkUnitOfWork.Transaction.cs
//     Fecha creación: 2021/10/26 at 09:06 AM
//     Fecha modificación: 2021/10/26 at 09:07 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace ReporteriaMovistar.Infrastructure.Data.Repositories
{
	public partial class EntityFrameworkUnitOfWork
	{
		#region Fields

		private IDbContextTransaction contextTransaction;

		#endregion

		#region IUnitOfWork Members

		public DbTransaction Transaction
		{
			get
			{
				return this.contextTransaction.GetDbTransaction();
			}
		}

		public async Task AutoCommitAsync()
		{
			await this.context.SaveChangesAsync();
		}

		public async Task BeginTransactionAsync()
		{
			this.contextTransaction = await this.context.Database.BeginTransactionAsync();
		}

		public void CommitTransaction()
		{
			this.context.Database.CommitTransaction();
		}

		public void RollbackTransaction()
		{
			this.context.Database.RollbackTransaction();
		}

		#endregion
	}
}