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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Clients.ApiPowerBi
// Info archivo:
//     Nombre: ApiAuthenticationMiddleware.cs
//     Fecha creación: 2021/11/25 at 06:13 PM
//     Fecha modificación: 2021/11/25 at 06:13 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using ReporteriaMovistar.Clients.ApiPowerBi.Database;
using ReporteriaMovistar.Clients.ApiPowerBi.DataProviders;
using ReporteriaMovistar.Clients.ApiPowerBi.Helpers;
using ReporteriaMovistar.Clients.ApiPowerBi.Repositories.Interfaces;

namespace ReporteriaMovistar.Clients.ApiPowerBi.Middleware
{
	public class ApiAuthenticationMiddleware
	{
		private readonly RequestDelegate next;

		private readonly IDbContextFactory<ReporteriaMovistarDbContext> dbContextFactory;

		private const string ApiKeyHeaderName = "ApiKey";

		public ApiAuthenticationMiddleware(RequestDelegate next, IDbContextFactory<ReporteriaMovistarDbContext> dbContextFactory)
		{
			this.next = next;
			this.dbContextFactory = dbContextFactory;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out StringValues extractedApiKey))
			{
				await SetUnauthorizedResponseAsync(context);
				return;
			}

			if (!await this.ApiKeyIsValidAsync(extractedApiKey))
			{
				await SetUnauthorizedResponseAsync(context);
				return;
			}

			await this.next(context);
		}

		private static async Task SetUnauthorizedResponseAsync(HttpContext context)
		{
			HttpResponse response = context.Response;
			response.ContentType = "application/json";
			response.StatusCode = (int) HttpStatusCode.Unauthorized;
			string result = JsonSerializer.Serialize(new { Message = "Usuario no autorizado." });
			await response.WriteAsync(result);
		}

		private async Task<bool> ApiKeyIsValidAsync(string apiKey)
		{
			await using (ReporteriaMovistarDbContext dbContext = this.dbContextFactory.CreateDbContext())
			{
				DatabaseService databaseService = new DatabaseService(this.dbContextFactory);
				databaseService.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = databaseService.UnitOfWorkFactory.Create())
				{
					return await unitOfWork.ApiUserEntities.ExistsKeyHashAsync(CryptographyUtils.Hash(apiKey));
				}
			}
		}
	}
}