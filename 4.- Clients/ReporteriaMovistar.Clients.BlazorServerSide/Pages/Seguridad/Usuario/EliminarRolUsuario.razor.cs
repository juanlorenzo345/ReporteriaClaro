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
//     Nombre: EliminarRolUsuario.razor.cs
//     Fecha creación: 2021/10/26 at 08:58 AM
//     Fecha modificación: 2021/10/26 at 08:58 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.View;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Models;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Seguridad.Usuario
{
	public partial class EliminarRolUsuario
	{
		[Parameter]
		public ViewRolUsuarioModel Modelo
		{
			get;
			set;
		}

		[Parameter]
		public string IdUsuario
		{
			get;
			set;
		}

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		[CascadingParameter]
		private MudDialogInstance MudDialog
		{
			get;
			set;
		}

		private void Cancelar()
		{
			MudDialog.Cancel();
		}

		private async Task EliminarAsync()
		{
			ApplicationUser usuario = null;

			try
			{
				usuario = await this.userManager.FindByIdAsync(IdUsuario);

				if (usuario is not null)
				{
					IdentityResult resultado = await this.userManager.RemoveFromRoleAsync(usuario, this.Modelo.Rol);

					if (resultado != IdentityResult.Success)
					{
						string mensajeError = string.Join("\r\n", $"Se produjo un error al quitar el rol '{this.Modelo.Rol}' del usuario '{usuario.UserName}'.", string.Join("\r\n", resultado.Errors.ToList()[0].Description));
						this.snackbar.Add(mensajeError, Severity.Error);
						return;
					}

					this.snackbar.Add($"El rol '{this.Modelo.Rol}' del usuario '{usuario.UserName}' se ha quitado correctamente.", Severity.Success);
					this.MudDialog.Close(DialogResult.Ok(this.Modelo));
				}
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al quitar el rol '{this.Modelo.Rol}' del usuario '{usuario?.UserName}'.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
		}
	}
}