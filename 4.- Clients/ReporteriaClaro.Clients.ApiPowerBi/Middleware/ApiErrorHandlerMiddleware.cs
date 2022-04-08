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
//     Nombre: ApiErrorHandlerMiddleware.cs
//     Fecha creación: 2021/11/26 at 10:33 AM
//     Fecha modificación: 2021/11/26 at 10:33 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ReporteriaClaro.Clients.ApiPowerBi.Exceptions;

namespace ReporteriaClaro.Clients.ApiPowerBi.Middleware
{
	public class ApiErrorHandlerMiddleware
	{
		private readonly RequestDelegate next;

		public ApiErrorHandlerMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await this.next(context);
			}
			catch (Exception exception)
			{
				HttpResponse response = context.Response;
				response.ContentType = "application/json";
				string result = null;
				switch (exception)
				{
					case ApiExcepcion:
					{
						response.StatusCode = (int) HttpStatusCode.BadRequest;
#if DEBUG
						result = JsonSerializer.Serialize(new { Message = exception.ToString() });
#else
						result = JsonSerializer.Serialize(new { Message = exception.Message.ToString() });
#endif
						break;
						}
					case KeyNotFoundException:
					{
						response.StatusCode = (int) HttpStatusCode.NotFound;
#if DEBUG
						result = JsonSerializer.Serialize(new { Message = exception.ToString() });
#else
						result = JsonSerializer.Serialize(new { Message = "Se produjo una excepción." });
#endif
						break;
						}
					default:
					{
						response.StatusCode = (int) HttpStatusCode.InternalServerError;
#if DEBUG
						result = JsonSerializer.Serialize(new { Message = exception.ToString() });
#else
						result = JsonSerializer.Serialize(new { Message = "Se produjo un error interno en el servidor." });
#endif
						break;
					}
				}
				await response.WriteAsync(result);
			}
		}
	}
}