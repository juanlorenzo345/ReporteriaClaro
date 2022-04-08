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
//     Nombre: ComponentLibraryServiceCollectionExtensions.cs
//     Fecha creación: 2021/10/25 at 09:43 AM
//     Fecha modificación: 2021/10/25 at 09:44 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Extensions.ServiceCollectionExtensions
{
	internal static class ComponentLibraryServiceCollectionExtensions
	{
		#region Methods

		internal static IServiceCollection AddComponentLibraryServices(this IServiceCollection services)
		{
			services.AddMudServices(config =>
			{
				config.SnackbarConfiguration = new SnackbarConfiguration()
				{
					PreventDuplicates = false,
					NewestOnTop = false,
					ShowCloseIcon = true,
					VisibleStateDuration = 10000,
					HideTransitionDuration = 500,
					ShowTransitionDuration = 500,
					SnackbarVariant = Variant.Filled,
					PositionClass = Defaults.Classes.Position.BottomRight
				};
			});
			return services;
		}

		#endregion
	}
}