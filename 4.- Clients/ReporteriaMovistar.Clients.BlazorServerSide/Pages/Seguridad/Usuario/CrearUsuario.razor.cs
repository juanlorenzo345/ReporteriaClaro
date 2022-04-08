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
//     Nombre: CrearUsuario.razor.cs
//     Fecha creación: 2021/10/26 at 08:55 AM
//     Fecha modificación: 2021/10/26 at 08:55 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using ReporteriaMovistar.Application.Models.Input.Choice;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Clients.BlazorServerSide.Data;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Models;
using ReporteriaMovistar.Clients.BlazorServerSide.Pages.Shared;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Seguridad.Usuario
{
	public partial class CrearUsuario
	{
		private MudForm formulario;

		private NewUsuarioModel modelo = new NewUsuarioModel();

		private ChoiceRolModel[] roles = new ChoiceRolModel[] { };

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

		private async Task<IEnumerable<ChoiceRolModel>> BuscarRolAsync(string rolBuscado)
		{
			try
			{
				bool esSuperAdmin = await UserInfo.IsInRoleAsync(AuthenticationStateTask, Roles.SuperAdministrador);
				Result<IEnumerable<IdentityRoleEntityDto>> resultadoRoles = await this.rolService.ObtenerListaRolesAsync(esSuperAdmin, rolBuscado);

				if (resultadoRoles.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la lista de roles.", string.Join("\r\n", resultadoRoles.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return Array.Empty<ChoiceRolModel>();
				}

				return resultadoRoles.Data.Select(c => new ChoiceRolModel() { Id = c.Id, Nombre = c.Name });
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar la lista de roles.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return Array.Empty<ChoiceRolModel>();
			}
		}

		public async Task GuardarAsync()
		{
			try
			{
				this.modelo.FechaCreacionRegistro = DateTime.Now;
				this.modelo.UsuarioCreacionRegistro = await UserInfo.GetUserNameAsync(AuthenticationStateTask);
				await this.formulario.Validate();

				if (!this.formulario.IsValid)
				{
					return;
				}

				this.userManager.PasswordHasher = new ApplicationPasswordHasher();
				IdentityResult resultado = await this.userManager.CreateAsync(CrearApplicationUserDesdeModelo(this.modelo), this.modelo.Contrasena);

				if (resultado != IdentityResult.Success)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al crear el usuario '{this.modelo.NombreUsuario}'.", string.Join("\r\n", resultado.Errors.ToList()[0].Description));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				ApplicationUser usuario = await this.userManager.FindByNameAsync(this.modelo.NombreUsuario);

				if (usuario is not null)
				{
					IdentityResult resultadoRol = await this.userManager.AddToRoleAsync(usuario, this.modelo.Rol.Nombre);

					if (resultadoRol != IdentityResult.Success)
					{
						string mensajeError = string.Join("\r\n", $"Se produjo un error al crear el rol '{this.modelo.Rol.Nombre}' del usuario '{this.modelo.NombreUsuario}'.", string.Join("\r\n", resultadoRol.Errors.ToList()[0].Description));
						this.snackbar.Add(mensajeError, Severity.Error);
						return;
					}

					this.snackbar.Add($"El usuario '{this.modelo.NombreUsuario}' se ha agregado correctamente.", Severity.Success);
					this.MudDialog.Close(DialogResult.Ok(this.modelo));
				}
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al crear el usuario '{this.modelo.NombreUsuario}'.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
		}

		private ApplicationUser CrearApplicationUserDesdeModelo(NewUsuarioModel modelo)
		{
			return new ApplicationUser()
			{
				UserName = modelo.NombreUsuario,
				FullName = modelo.NombreCompleto,
				CreatedAt = modelo.FechaCreacionRegistro,
				CreatedBy = modelo.UsuarioCreacionRegistro,
				Active = modelo.Activo
			};
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