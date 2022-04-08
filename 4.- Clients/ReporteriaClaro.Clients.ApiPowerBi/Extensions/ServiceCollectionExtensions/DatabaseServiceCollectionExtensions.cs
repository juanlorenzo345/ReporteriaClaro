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
//     Nombre: DatabaseServiceCollectionExtensions.cs
//     Fecha creación: 2021/11/25 at 05:14 PM
//     Fecha modificación: 2021/11/25 at 05:14 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReporteriaClaro.Clients.ApiPowerBi.DataProviders;

namespace ReporteriaClaro.Clients.ApiPowerBi.Extensions.ServiceCollectionExtensions
{
	internal static class DatabaseServiceCollectionExtensions
	{
		private const string ConnectionString = "DbReporteriaClaro";

		internal static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContextFactory<ReporteriaClaroDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString(ConnectionString), options =>
					options.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds))
					.ReplaceService<IQueryTranslationPostprocessorFactory, SqlServer2008QueryTranslationPostprocessorFactory>(),
					ServiceLifetime.Transient);

			return services;
		}
	}
}