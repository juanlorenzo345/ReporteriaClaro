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
//     Nombre: RedirectToLogin.razor.cs
//     Fecha creación: 2021/10/25 at 11:01 AM
//     Fecha modificación: 2021/10/25 at 11:01 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Shared.Authentication
{
	public partial class RedirectToLogin
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		protected override async Task OnInitializedAsync()
		{
			AuthenticationState authenticationState = await this.AuthenticationStateTask;

			if (authenticationState?.User?.Identity is null || !authenticationState.User.Identity.IsAuthenticated)
			{
				string returnUrl = this.navigationManager!.ToBaseRelativePath(this.navigationManager.Uri);

				if (string.IsNullOrWhiteSpace(returnUrl))
				{
					this.navigationManager.NavigateTo(PageRoutes.Login, true);
				}

				this.navigationManager.NavigateTo($"{PageRoutes.Login}?returnUrl={returnUrl}", true);
			}
		}
	}
}