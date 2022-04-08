using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using ReporteriaClaro.Clients.BlazorServerSide.Pages.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReporteriaClaro.Application.Models.Input.Choice;
using ReporteriaClaro.Application.Models.Input.Insert;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.Modelo
{
    public partial class EditarModeloEquipo
    {
		private MudForm formulario;

		private UpdateModeloEquipoModel modelo = new UpdateModeloEquipoModel();

		private ChoiceTecnologiaEquipoModel[] tecnologias = new ChoiceTecnologiaEquipoModel[] { };

		[Parameter]
		public int Id
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
			await CargarListasAsync();
			await CargarDatosAsync();
		}

		private async Task CargarListasAsync()
		{
			this.tecnologias = await this.tecnologiaData.ObtenerListaTecnologiasAsync(this.AuthenticationStateTask);
		}

		private async Task CargarDatosAsync()
		{
			Result<EquipoModeloEntityDto> resultadoModelo = await this.modeloEquipoService.ObtenerModeloPorIdAsync(Id);

			if (resultadoModelo.Type != ResultType.Succeeded)
			{
				this.snackbar.Add($"Se produjo un error al cargar los datos del modelo. {string.Join("\r\n", resultadoModelo.Errors)}", Severity.Error);
				MudDialog.Cancel();
				return;
			}

			EquipoModeloEntityDto dto = resultadoModelo.Data;
			this.modelo.Id = dto.Id;
			this.modelo.Nombre = dto.Nombre;
			this.modelo.Marca = new ChoiceMarcaEquipoModel() { Id = dto.EquipoMarcaEntity.Id, Nombre = dto.EquipoMarcaEntity.Nombre };
			this.modelo.Tecnologia = dto.EquipoTecnologiaEntity is not null ? new ChoiceTecnologiaEquipoModel() { Id = dto.EquipoTecnologiaEntity.Id, Nombre = dto.EquipoTecnologiaEntity.Nombre } : new ChoiceTecnologiaEquipoModel() { Id = -1, Nombre = string.Empty };
		}

		public async Task GuardarAsync()
		{
			try
			{
				this.modelo.Id = Id;
				this.modelo.FechaModificacionRegistro = DateTime.Now;
				this.modelo.UsuarioModificacionRegistro = await UserInfo.GetUserNameAsync(AuthenticationStateTask);
				await this.formulario.Validate();

				if (!this.formulario.IsValid)
				{
					return;
				}

				Result resultado = await this.modeloEquipoService.ModificarModeloAsync(modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al modificar el modelo '{this.modelo.Nombre}' (ID {this.Id}).", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El modelo '{this.modelo.Nombre}' se ha modificado correctamente (ID {this.Id}).", Severity.Success);
				MudDialog.Close(DialogResult.Ok(this.modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al modificar el modelo '{this.modelo.Nombre}' (ID {this.Id}).", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new Application.Models.Input.Insert.NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
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
