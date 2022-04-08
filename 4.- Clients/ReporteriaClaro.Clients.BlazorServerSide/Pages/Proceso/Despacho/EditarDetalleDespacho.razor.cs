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
//     Nombre: EditarDetalleDespacho.razor.cs
//     Fecha creación: 2021/11/11 at 12:30 PM
//     Fecha modificación: 2021/11/11 at 12:30 PM
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
using MudBlazor;
using ReporteriaClaro.Application.Models.Input.Choice;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using ReporteriaClaro.Clients.BlazorServerSide.Pages.Shared;
using Serilog;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Proceso.Despacho
{
	public partial class EditarDetalleDespacho
	{
		private MudForm formulario;

		private UpdateDetalleDespachoModel modelo = new UpdateDetalleDespachoModel();

		private ChoiceEstadoComponenteModel[] estadosFuentePoder = new ChoiceEstadoComponenteModel[] { };

		private ChoiceEstadoComponenteModel[] estadosUtp = new ChoiceEstadoComponenteModel[] { };

		private ChoiceEstadoComponenteModel[] estadosControlRemoto = new ChoiceEstadoComponenteModel[] { };

		private ChoiceEstadoComponenteModel[] estadosHdmi = new ChoiceEstadoComponenteModel[] { };

		private ChoiceEstadoComponenteModel[] estadosRca = new ChoiceEstadoComponenteModel[] { };

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
			this.estadosFuentePoder = await this.estadoComponenteData.ObtenerListaEstadosAsync(this.AuthenticationStateTask);
			this.estadosUtp = this.estadosFuentePoder;
			this.estadosControlRemoto = this.estadosFuentePoder;
			this.estadosHdmi = this.estadosFuentePoder;
			this.estadosRca = this.estadosFuentePoder;
		}

		private async Task CargarDatosAsync()
		{
			Result<DespachoDetalleEntityDto> resultadoDetalle = await this.detalleDespachoService.ObtenerDetallePorIdAsync(Id);

			if (resultadoDetalle.Type != ResultType.Succeeded)
			{
				this.snackbar.Add($"Se produjo un error al cargar los datos del detalle de despacho. {string.Join("\r\n", resultadoDetalle.Errors)}", Severity.Error);
				MudDialog.Cancel();
				return;
			}

			DespachoDetalleEntityDto dto = resultadoDetalle.Data;
			this.modelo.Id = dto.Id;
			this.modelo.Equipo = new ChoiceEquipoModel() { Id = dto.EquipoEntity.Id, Esn = dto.EquipoEntity.Esn, Marca = dto.EquipoEntity.EquipoModeloEntity.EquipoMarcaEntity.Nombre, Modelo = dto.EquipoEntity.EquipoModeloEntity.Nombre, Color = dto.EquipoEntity.EquipoColorEntity.Nombre, IdTecnologia = dto.EquipoEntity.EquipoModeloEntity.TecnologiaId };
			this.modelo.Caja = dto.Caja;
			this.modelo.Pallet = dto.Pallet;
			this.modelo.Derivada = dto.EquipoEntity.Derivada;
			this.modelo.Pintura = dto.EquipoEntity.Pintura;
			this.modelo.ProcesoFinalizado = dto.EquipoEntity.ProcesoFinalizado;
			this.modelo.EstadoFuentePoder = new ChoiceEstadoComponenteModel() { Id = dto.EquipoEntity.ComponenteEstadoEntity_FuentePoderEstadoId.Id, Nombre = dto.EquipoEntity.ComponenteEstadoEntity_FuentePoderEstadoId.Nombre };
			this.modelo.EstadoUtp = new ChoiceEstadoComponenteModel() { Id = dto.EquipoEntity.ComponenteEstadoEntity_UtpEstadoId.Id, Nombre = dto.EquipoEntity.ComponenteEstadoEntity_UtpEstadoId.Nombre };
			this.modelo.EstadoControlRemoto = new ChoiceEstadoComponenteModel() { Id = dto.EquipoEntity.ComponenteEstadoEntity_ControlRemotoEstadoId.Id, Nombre = dto.EquipoEntity.ComponenteEstadoEntity_ControlRemotoEstadoId.Nombre };
			this.modelo.EstadoHdmi = new ChoiceEstadoComponenteModel() { Id = dto.EquipoEntity.ComponenteEstadoEntity_HdmiEstadoId.Id, Nombre = dto.EquipoEntity.ComponenteEstadoEntity_HdmiEstadoId.Nombre };
			this.modelo.EstadoRca = new ChoiceEstadoComponenteModel() { Id = dto.EquipoEntity.ComponenteEstadoEntity_RcaEstadoId.Id, Nombre = dto.EquipoEntity.ComponenteEstadoEntity_RcaEstadoId.Nombre };
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

				Result resultado = await this.detalleDespachoService.ModificarDetalleAsync(this.modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al modificar el equipo con ESN '{this.modelo.Equipo.Esn}' del despacho actual (ID {this.Id}).", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El equipo con ESN '{this.modelo.Equipo.Esn}' se ha modificado correctamente (ID {this.Id}).", Severity.Success);
				MudDialog.Close(DialogResult.Ok(this.modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al modificar el equipo con ESN '{this.modelo.Equipo.Esn}' del despacho actual (ID {this.Id}).", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
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