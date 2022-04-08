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
//     Nombre: IUnitOfWork.Transaction.cs
//     Fecha creación: 2021/10/26 at 09:04 AM
//     Fecha modificación: 2021/10/26 at 09:05 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Data.Common;
using System.Threading.Tasks;

namespace ReporteriaClaro.Domain.Interfaces.Repositories
{
	public partial interface IUnitOfWork
	{
		#region Properties and Indexers

		public DbTransaction Transaction
		{
			get;
		}

		#endregion

		#region Methods

		public Task AutoCommitAsync();

		public Task BeginTransactionAsync();

		public void CommitTransaction();

		public void RollbackTransaction();

		#endregion
	}
}