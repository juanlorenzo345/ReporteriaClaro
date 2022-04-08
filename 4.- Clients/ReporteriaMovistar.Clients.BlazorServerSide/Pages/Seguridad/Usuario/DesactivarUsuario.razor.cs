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
//     Nombre: DesactivarUsuario.razor.cs
//     Fecha creación: 2021/11/05 at 11:47 AM
//     Fecha modificación: 2021/11/05 at 11:47 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.View;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Seguridad.Usuario
{
	public partial class DesactivarUsuario
	{
		private UpdateActivacionUsuarioModel modelo = new UpdateActivacionUsuarioModel() { Activo = false };

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
		public ViewUsuarioModel Modelo
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
			this.snackbar.Add($"No se ha desactivado al usuario {this.Modelo.Usuario} (ID: {this.Modelo.Id}).", Severity.Warning);
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
				this.modelo.FechaDesactivacion = DateTime.Now;
				this.modelo.UsuarioDesactivacion = await UserInfo.GetUserNameAsync(AuthenticationStateTask);

				await this.formulario.Validate();

				if (!this.formulario.IsValid)
				{
					return;
				}

				Result resultado = await this.usuarioService.ModificarActivacionUsuarioAsync(this.modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al desactivar el usuario '{this.Modelo.Usuario}' (ID: {this.Modelo.Id}).",
					string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El usuario '{this.Modelo.Usuario}' se ha desactivado correctamente (ID: {this.Modelo.Id}).", Severity.Success);
				MudDialog.Close(DialogResult.Ok(""));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al desactivar el usuario '{this.Modelo.Usuario}' (ID: {this.Modelo.Id}).", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
		}

		#endregion
	}
}