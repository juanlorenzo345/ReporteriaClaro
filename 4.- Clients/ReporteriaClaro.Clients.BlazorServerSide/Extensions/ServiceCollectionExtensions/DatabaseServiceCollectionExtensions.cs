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
// Solución/Proyecto: TsaDotNet / TsaDotNet.Server.BlazorWasm
// Info archivo:
//     Nombre: DatabaseServiceCollectionExtensions.cs
//     Fecha creación: 2021/10/01 at 04:16 PM
//     Fecha modificación: 2021/10/01 at 04:16 PM
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
using ReporteriaClaro.Clients.BlazorServerSide.Data;
using ReporteriaClaro.Clients.BlazorServerSide.IdentityData;
using ReporteriaClaro.Infrastructure.Data.DataProviders;

namespace ReporteriaClaro.Clients.BlazorServerSide.Extensions.ServiceCollectionExtensions
{
	internal static class DatabaseServiceCollectionExtensions
	{
		private const string ConnectionString = "DbReporteriaClaro";

		internal static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
				configuration.GetConnectionString(ConnectionString)));

			services.AddDbContextFactory<ReporteriaClaroDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString(ConnectionString), options =>
					options.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds))
						.ReplaceService<IQueryTranslationPostprocessorFactory, SqlServer2008QueryTranslationPostprocessorFactory>(),
				ServiceLifetime.Transient);

			services.AddDatabaseDeveloperPageExceptionFilter();
			 
			return services;
		}
	}
}