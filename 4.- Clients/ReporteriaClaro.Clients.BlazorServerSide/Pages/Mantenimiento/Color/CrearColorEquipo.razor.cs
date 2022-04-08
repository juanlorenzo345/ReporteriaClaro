using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using ReporteriaClaro.Clients.BlazorServerSide.Pages.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReporteriaClaro.Application.Models.Output;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.Color
{
    public partial class CrearColorEquipo
    {
        private MudForm formulario;

        private NewColorEquipoModel modelo = new NewColorEquipoModel();

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

		public async Task GuardarAsync()
        {
            try
            {
				this.modelo.FechaCreacionRegistro = DateTime.Now;
				this.modelo.UsuarioCreacionRegistro = await UserInfo.GetUserNameAsync(AuthenticationStateTask);
				await this.formulario.Validate();

				if(!this.formulario.IsValid)
                {
					return;
                }

				Result resultado = await this.colorEquipoService.CrearColorAsync(modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al crear el color '{this.modelo.Nombre}'.", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El color '{this.modelo.Nombre}' se ha creado correctamente.", Severity.Success);
				MudDialog.Close(DialogResult.Ok(this.modelo));
			}
			catch(Exception excepcion)
            {
				this.snackbar.Add($"Se produjo un error al crear el color '{this.modelo.Nombre}'.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
            }
        }

		public async Task CancelarAsync()
        {
			DialogResult resultado = await this.dialogService.Show<DescartarCambios>("Descartar cambios").Result;
			
			if(!resultado.Cancelled)
            {
				MudDialog.Cancel();
            }
        }
	}
}
