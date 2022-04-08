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
//     Nombre: EditarUsuario.razor.cs
//     Fecha creación: 2021/10/26 at 08:55 AM
//     Fecha modificación: 2021/10/26 at 08:55 AM
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
using ReporteriaClaro.Application.Models.Input.Choice;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Clients.BlazorServerSide.Data;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using ReporteriaClaro.Clients.BlazorServerSide.IdentityData;
using ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Models;
using ReporteriaClaro.Clients.BlazorServerSide.Pages.Shared;
using Serilog;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Seguridad.Usuario
{
	public partial class EditarUsuario
	{
		private MudForm formulario;

		private UpdateUsuarioModel modelo = new UpdateUsuarioModel();

		[Parameter]
		public string Id
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

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			ConfigurarDialogo();
		}

		private void ConfigurarDialogo()
		{
			this.MudDialog.Options.CloseButton = false;
			this.MudDialog.Options.DisableBackdropClick = true;
			this.MudDialog.Options.Position = DialogPosition.Center;
			this.MudDialog.SetOptions(this.MudDialog.Options);
		}

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			await CargarDatosAsync();
		}

		private async Task CargarDatosAsync()
		{
			Result<IdentityUserEntityDto> resultadoEtapa = await this.usuarioService.ObtenerUsuarioPorIdAsync(Id);

			if (resultadoEtapa.Type != ResultType.Succeeded)
			{
				this.snackbar.Add($"Se produjo un error al cargar los datos del usuario. {string.Join("\r\n", resultadoEtapa.Errors)}", Severity.Error);
				MudDialog.Cancel();
				return;
			}

			IdentityUserEntityDto dto = resultadoEtapa.Data;
			this.modelo.Id = dto.Id;
			this.modelo.NombreUsuario = dto.UserName;
			this.modelo.NombreCompleto = dto.FullName;
		}

		public async Task GuardarAsync()
		{
			try
			{
				this.modelo.Id = this.Id;
				this.modelo.FechaModificacionRegistro = DateTime.Now;
				this.modelo.UsuarioModificacionRegistro = await UserInfo.GetUserNameAsync(AuthenticationStateTask);
				await this.formulario.Validate();

				if (!this.formulario.IsValid)
				{
					return;
				}

				this.userManager.PasswordHasher = new ApplicationPasswordHasher();
				ApplicationUser usuario = await this.userManager.FindByIdAsync(Id);

				if (this.modelo.CambiarContrasena)
				{
					string token = await this.userManager.GeneratePasswordResetTokenAsync(usuario);
					IdentityResult resultadoCambioContrasena = await this.userManager.ResetPasswordAsync(usuario, token, this.modelo.Contrasena);
					
					if (resultadoCambioContrasena != IdentityResult.Success)
					{
						string mensajeError = string.Join("\r\n", $"Se produjo un error al modificar la contraseña del usuario '{this.modelo.NombreUsuario}'.", string.Join("\r\n", resultadoCambioContrasena.Errors.ToList()[0].Description));
						this.snackbar.Add(mensajeError, Severity.Error);
						return;
					}
				}

				ModificarApplicationUserDesdeModelo(usuario, modelo);
				IdentityResult resultadoModificarUsuario = await this.userManager.UpdateAsync(usuario);

				if (resultadoModificarUsuario != IdentityResult.Success)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al modificar el usuario '{this.modelo.NombreUsuario}' (ID {this.Id}).", string.Join("\r\n", resultadoModificarUsuario.Errors.ToList()[0].Description));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El usuario '{this.modelo.NombreUsuario}' se ha modificado correctamente (ID {this.Id}).", Severity.Success);
				this.MudDialog.Close(DialogResult.Ok(this.modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al modificar el usuario '{this.modelo.NombreUsuario}' (ID {this.Id}).", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel()
				{
					IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask),
					Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace,
					Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now
				});
			}
		}

		private void ModificarApplicationUserDesdeModelo(ApplicationUser usuario, UpdateUsuarioModel modelo)
		{
			usuario.FullName = modelo.NombreCompleto;
			usuario.ModifiedAt = modelo.FechaModificacionRegistro;
			usuario.ModifiedBy = modelo.UsuarioModificacionRegistro;
		}

		public async Task CancelarAsync()
		{
			DialogResult resultado = await this.dialogService.Show<DescartarCambios>("Descartar cambios").Result;

			if (!resultado.Cancelled)
			{
				MudDialog.Cancel();
			}
		}
	}
}