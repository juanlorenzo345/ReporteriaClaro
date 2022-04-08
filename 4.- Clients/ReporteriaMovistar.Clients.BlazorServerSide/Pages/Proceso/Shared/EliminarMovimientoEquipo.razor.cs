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
//     Nombre: EliminarMovimientoEquipo.razor.cs
//     Fecha creación: 2021/11/09 at 10:40 AM
//     Fecha modificación: 2021/11/09 at 10:40 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ReporteriaMovistar.Application.Models.Input.Delete;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.View;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Proceso.Shared
{
	public partial class EliminarMovimientoEquipo
	{
		#region Properties and Indexers

		[Parameter]
		public ViewMovimientoEquipoModel Modelo
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

		#endregion

		#region Methods

		protected override void OnInitialized()
		{
			base.OnInitialized();
			ConfigurarDialogo();
		}

		private void ConfigurarDialogo()
		{
			MudDialog.Options.CloseButton = false;
			MudDialog.Options.DisableBackdropClick = true;
			MudDialog.Options.Position = DialogPosition.Center;
			MudDialog.SetOptions(MudDialog.Options);
		}

		private void Cancelar()
		{
			MudDialog.Cancel();
		}

		private async Task EliminarAsync()
		{
			try
			{
				Result resultado = await this.movimientoEquipoService.EliminarMovimientoAsync(
				new DeleteModelBase<int>()
				{
					Id = Modelo.Id,
					FechaEliminacionRegistro = DateTime.Now,
					UsuarioEliminacionRegistro = await UserInfo.GetUserNameAsync(AuthenticationStateTask)
				});

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al eliminar el movimiento de la ESN '{this.Modelo.Esn}' (ID {this.Modelo.Id}).", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El movimiento de la ESN '{this.Modelo.Esn}' se ha eliminado correctamente (ID {this.Modelo.Id}).", Severity.Success);
				this.MudDialog.Close(DialogResult.Ok(Modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al eliminar el movimiento de la ESN '{this.Modelo.Esn}' (ID {this.Modelo.Id}).", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
		}

		#endregion
	}
}