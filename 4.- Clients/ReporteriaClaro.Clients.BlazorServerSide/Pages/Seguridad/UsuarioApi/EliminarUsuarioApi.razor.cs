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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Clients.BlazorServerSide
// Info archivo:
//     Nombre: EliminarUsuarioApi.razor.cs
//     Fecha creación: 2021/11/29 at 12:22 PM
//     Fecha modificación: 2021/11/29 at 12:22 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.View;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Seguridad.UsuarioApi
{
	public partial class EliminarUsuarioApi
	{
		private DeleteUsuarioApiModel modelo = new DeleteUsuarioApiModel();

		private MudForm formulario;

		#region Properties and Indexers

		[CascadingParameter]
		private MudDialogInstance MudDialog
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

		[Parameter]
		public ViewUsuarioApiModel Modelo
		{
			get;
			set;
		}

		#endregion

		#region Methods

		protected override void OnInitialized()
		{
			base.OnInitialized();
			ConfigurarDialogo();
		}

		private void Cancelar()
		{
			this.snackbar.Add($"No se ha desactivado la API key con ID {this.Modelo.Id}.", Severity.Warning);
			this.MudDialog.Cancel();
		}

		private void ConfigurarDialogo()
		{
			MudDialog.Options.CloseButton = false;
			MudDialog.Options.DisableBackdropClick = true;
			MudDialog.Options.Position = DialogPosition.Center;
			MudDialog.SetOptions(MudDialog.Options);
		}


		private async Task DesactivarAsync()
		{
			try
			{
				this.modelo.Id = this.Modelo.Id;
				this.modelo.FechaEliminacionRegistro = DateTime.Now;
				this.modelo.UsuarioEliminacionRegistro = await UserInfo.GetUserNameAsync(AuthenticationStateTask);

				await this.formulario.Validate();

				if (!this.formulario.IsValid)
				{
					return;
				}

				Result resultado = await this.usuarioApiService.EliminarUsuarioAsync(this.modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al desactivar la API key con ID {this.Modelo.Id}.",
					string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"La API key con ID {this.Modelo.Id} se ha desactivado correctamente.", Severity.Success);
				MudDialog.Close(DialogResult.Ok(""));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al desactivar la API key con ID {this.Modelo.Id}.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
		}

		#endregion
	}
}