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
//     Nombre: UserInfo.cs
//     Fecha creación: 2021/11/02 at 10:45 AM
//     Fecha modificación: 2021/11/02 at 10:45 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Helpers
{
	internal static class UserInfo
	{
		/// <summary>
		/// Obtiene el nombre del usuario actual asincrónicamente.
		/// </summary>
		/// <param name="authenticationStateTask">Estado de autenticación.</param>
		/// <returns>Devuelve un string con el nombre del usuario actual.</returns>
		internal static async Task<string> GetUserNameAsync(Task<AuthenticationState> authenticationStateTask)
		{
			AuthenticationState authState = await authenticationStateTask;

			if (authState.User.Identity?.IsAuthenticated == true)
			{
				return authState.User.Identity.Name;
			}

			return "Desconocido";
		}

		/// <summary>
		/// Obtiene el ID del usuario actual asincrónicamente.
		/// </summary>
		/// <param name="authenticationStateTask">Estado de autenticación.</param>
		/// <returns>Devuelve un string con el ID del usuario actual.</returns>
		internal static async Task<string> GetUserIdAsync(Task<AuthenticationState> authenticationStateTask)
		{
			AuthenticationState authState = await authenticationStateTask;

			if (authState.User.Identity?.IsAuthenticated == true)
			{
				return authState.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
			}

			return "";
		}

		/// <summary>
		/// Indica si el usuario actual tiene el rol especificado asincrónicamente.
		/// </summary>
		/// <param name="authenticationStateTask">Estado de autenticación.</param>
		/// <param name="role">Rol a comprobar.</param>
		/// <returns>Devuelve un bool indicando true si el usuario tiene el rol especificado, en caso contrario false.</returns>
		internal static async Task<bool> IsInRoleAsync(Task<AuthenticationState> authenticationStateTask, string role)
		{
			AuthenticationState authState = await authenticationStateTask;

			if (authState.User.Identity?.IsAuthenticated == true)
			{
				return authState.User.IsInRole(role);
			}

			return false;
		}
	}
}