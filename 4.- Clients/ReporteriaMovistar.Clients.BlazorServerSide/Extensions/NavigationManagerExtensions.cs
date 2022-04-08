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
//     Nombre: NavigationManagerExtensions.cs
//     Fecha creación: 2021/10/25 at 09:31 AM
//     Fecha modificación: 2021/10/25 at 09:44 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Extensions
{
	internal static class NavigationManagerExtensions
	{
		#region Methods

		/// <summary>
		/// Gets the link of the component on the documentation page
		/// Ex: /api/button; "button" is the component link, and "api" is the section
		/// </summary>
		internal static string GetComponentLink(this NavigationManager navigationManager)
		{
			Uri currentUri = new Uri(navigationManager.Uri);
			return currentUri.AbsolutePath
			.Split("/", StringSplitOptions.RemoveEmptyEntries)
			//the second element
			.ElementAtOrDefault(1);
		}

		/// <summary>
		/// Gets the section part of the documentation page
		/// Ex: /components/button;  "components" is the section
		/// </summary>
		internal static string GetSection(this NavigationManager navigationManager)
		{
			Uri currentUri = new Uri(navigationManager.Uri);
			return currentUri.AbsolutePath
			.Split("/", StringSplitOptions.RemoveEmptyEntries)
			.FirstOrDefault();
		}

		/// <summary>
		/// Determines if the current page is the base page
		/// </summary>
		internal static bool IsHomePage(this NavigationManager navigationManager)
		{
			return navigationManager.Uri == navigationManager.BaseUri;
		}

		#endregion
	}
}