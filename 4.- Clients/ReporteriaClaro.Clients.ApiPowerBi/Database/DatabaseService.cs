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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Clients.ApiPowerBi
// Info archivo:
//     Nombre: DatabaseService.cs
//     Fecha creación: 2021/11/26 at 10:07 AM
//     Fecha modificación: 2021/11/26 at 10:07 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Clients.ApiPowerBi.DataProviders;
using ReporteriaClaro.Clients.ApiPowerBi.Repositories;
using ReporteriaClaro.Clients.ApiPowerBi.Repositories.Interfaces;

namespace ReporteriaClaro.Clients.ApiPowerBi.Database
{
	internal class DatabaseService
	{
		protected readonly IDbContextFactory<ReporteriaClaroDbContext> DbContextFactory;

		internal IUnitOfWorkFactory UnitOfWorkFactory;

		internal DatabaseService(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory)
		{
			this.DbContextFactory = dbContextFactory;
		}

		internal void InitializeUnitOfWork(ReporteriaClaroDbContext dbContext)
		{
			if (dbContext is null)
			{
				throw new ArgumentNullException(nameof(dbContext), $"El contexto no puede ser null.");
			}

			this.UnitOfWorkFactory = new EntityFrameworkUnitOfWorkFactory(dbContext);
		}
	}
}