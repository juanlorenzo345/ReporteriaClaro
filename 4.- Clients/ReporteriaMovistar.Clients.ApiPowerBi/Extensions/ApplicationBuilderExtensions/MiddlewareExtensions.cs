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
//     Nombre: MiddlewareExtensions.cs
//     Fecha creación: 2021/11/26 at 11:44 AM
//     Fecha modificación: 2021/11/26 at 11:44 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.AspNetCore.Builder;
using ReporteriaMovistar.Clients.ApiPowerBi.Middleware;

namespace ReporteriaMovistar.Clients.ApiPowerBi.Extensions.ApplicationBuilderExtensions
{
	internal static class MiddlewareExtensions
	{
		internal static IApplicationBuilder UseApiAuthentication(this IApplicationBuilder app)
		{
			app.UseMiddleware<ApiAuthenticationMiddleware>();
			return app;
		}

		internal static IApplicationBuilder UseApiErrorHandler(this IApplicationBuilder app)
		{
			app.UseMiddleware<ApiErrorHandlerMiddleware>();
			return app;
		}
	}
}