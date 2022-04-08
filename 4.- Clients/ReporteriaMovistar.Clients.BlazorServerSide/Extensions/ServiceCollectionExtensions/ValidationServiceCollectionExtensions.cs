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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Clients.BlazorServerSide
// Info archivo:
//     Nombre: ValidationServiceCollectionExtensions.cs
//     Fecha creación: 2021/10/25 at 09:43 AM
//     Fecha modificación: 2021/10/25 at 09:44 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Extensions.ServiceCollectionExtensions
{
	internal static class ValidationServiceCollectionExtensions
	{
		#region Methods

		internal static IServiceCollection AddValidationServices(this IServiceCollection services)
		{
			Assembly ensamblado = Assembly.Load("ReporteriaMovistar.Application.Models");
			//services.AddValidatorsFromAssemblyContaining<LoginRequestModel>();
			services.AddMvc().AddFluentValidation(f =>
			f.RegisterValidatorsFromAssembly(ensamblado));
			services.AddValidatorsFromAssembly(ensamblado);
			return services;
		}

		#endregion
	}
}