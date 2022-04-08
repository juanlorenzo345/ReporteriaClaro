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
//     Nombre: CrearMovimientoEquipo.razor.cs
//     Fecha creación: 2021/11/09 at 10:40 AM
//     Fecha modificación: 2021/11/09 at 10:40 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using ReporteriaMovistar.Application.Models.Enums;
using ReporteriaMovistar.Application.Models.Input.Choice;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using ReporteriaMovistar.Clients.BlazorServerSide.Pages.Shared;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Proceso.Shared
{
	public partial class CrearMovimientoEquipo
	{
		private MudForm formularioMovimiento;

		private MudForm formularioBulkMovimiento;

		private MudTextField<string> textFieldEsn;

		private NewMovimientoEquipoModel modeloMovimiento = new NewMovimientoEquipoModel();

		private NewBulkMovimientoEquipoModel modeloBulkMovimiento = new NewBulkMovimientoEquipoModel();

		private ChoiceEtapaModel[] etapasDestino = new ChoiceEtapaModel[] { };

		[Parameter]
		public Etapa Etapa
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
			this.MudDialog.Options.FullScreen = true;
			this.MudDialog.Options.Position = DialogPosition.Center;
			this.MudDialog.SetOptions(this.MudDialog.Options);
		}

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			await CargarListasAsync();
		}

		private async Task CargarListasAsync()
		{
			this.etapasDestino = await this.etapaData.ObtenerListaEtapasDestinoAsync(this.Etapa, this.AuthenticationStateTask);
		}

		private void AgregarEquipo()
		{
			if (this.modeloBulkMovimiento.Movimientos.Exists(m => m.Equipo.Id == this.modeloMovimiento.Equipo.Id))
			{
				this.snackbar.Add($"Ya se agregó el ESN '{this.modeloMovimiento.Equipo.Esn}' a la lista.", Severity.Warning);
				return;
			}

			this.modeloBulkMovimiento.Movimientos.Insert(-0, new NewMovimientoEquipoModel()
			{
				Fecha = this.modeloMovimiento.Fecha,
				Hora = this.modeloMovimiento.Hora,
				Equipo = this.modeloMovimiento.Equipo,
				EtapaOrigen = new ChoiceEtapaModel() { Id = (int)this.Etapa },
				EtapaDestino = this.modeloMovimiento.EtapaDestino,
				Operario = this.modeloMovimiento.Operario,
				OperarioDevolucion = this.modeloMovimiento.EtapaDestino.EsEtapaAnterior ? this.modeloMovimiento.OperarioDevolucion : null,
				Observacion = this.modeloMovimiento.Observacion
			});

			this.snackbar.Add($"El ESN '{this.modeloMovimiento.Equipo.Esn}' se ha agregado correctamente.", Severity.Success);
		}

		private void QuitarEquipo(NewMovimientoEquipoModel context)
		{
			this.modeloBulkMovimiento.Movimientos.Remove(context);
		}

		private async Task ValidarTeclaPresionadaAsync(KeyboardEventArgs args)
		{
			if (args.Code == "Enter" || args.Code == "NumpadEnter")
			{
				await BuscarPorEsnAsync();
			}
		}

		private async Task BuscarPorEsnAsync()
		{
			this.modeloMovimiento.Equipo = (await this.equipoData.BuscarEquipoAsync(this.modeloMovimiento.Esn, this.AuthenticationStateTask)).DefaultIfEmpty(new ChoiceEquipoModel() { Id = -1, Esn = string.Empty, Marca = string.Empty, Modelo = string.Empty, Color = string.Empty, IdTecnologia = -1 }).First();

			if (this.modeloMovimiento.Equipo.Id <= 0 || string.IsNullOrWhiteSpace(this.modeloMovimiento.Equipo.Esn))
			{
				this.snackbar.Add($"El equipo con ESN '{this.modeloMovimiento.Esn}' no existe.", Severity.Warning);
				await LimpiarCamposDetalleAsync();
				return;
			}

			if (this.modeloMovimiento.EtapaDestino.EsEtapaAnterior || this.Etapa == Etapa.Pintura)
			{
				await ObtenerUltimoOperarioEtapaAsync();
			}

			await this.formularioMovimiento.Validate();
			if (!this.formularioMovimiento.IsValid)
			{
				await LimpiarCamposDetalleAsync();
				return;
			}

			AgregarEquipo();
			this.modeloMovimiento.Observacion = string.Empty;
			this.modeloMovimiento.Equipo = new ChoiceEquipoModel() { Id = -1, Esn = string.Empty, Marca = string.Empty, Modelo = string.Empty, Color = string.Empty, IdTecnologia = -1 };
			await LimpiarCamposDetalleAsync();
		}

		private async Task LimpiarCamposDetalleAsync()
		{
			//this.modeloMovimiento.OperarioDevolucion = new ChoiceOperarioModel() { Id = -1, Nombre = string.Empty };
			await this.textFieldEsn.Clear();
			await this.textFieldEsn.FocusAsync();
		}

		private async Task ObtenerUltimoOperarioEtapaAsync()
		{
			Log.Information($"pruebaaa, ID equipo: {this.modeloMovimiento.Equipo?.Id}");

			if (this.modeloMovimiento.Equipo is null)
			{
				return;
			}

			Result<SPUltimoOperarioEtapaEntityResultDto> resultado = await this.movimientoEquipoService.ObtenerUltimoOperarioEtapaAsync(this.modeloMovimiento.Equipo.Id, this.modeloMovimiento.EtapaDestino.Id);

			if (resultado.Type != ResultType.Succeeded)
			{
				return;
			}

			SPUltimoOperarioEtapaEntityResultDto dto = resultado.Data;
			
			if (dto is not null)
			{
				this.modeloMovimiento.OperarioDevolucion = new ChoiceOperarioModel() { Id = dto.Id, Nombre = dto.Nombre };
			}
		}

		private async Task GuardarAsync()
		{
			try
			{
				string usuario = await UserInfo.GetUserNameAsync(AuthenticationStateTask);
				this.modeloBulkMovimiento.Movimientos = this.modeloBulkMovimiento.Movimientos.Select(m =>
				{
					m.FechaCreacionRegistro = DateTime.Now;
					m.UsuarioCreacionRegistro = usuario;
					return m;
				}).ToList();
				await this.formularioBulkMovimiento.Validate();

				if (!this.formularioBulkMovimiento.IsValid)
				{
					return;
				}

				Result resultado = await this.movimientoEquipoService.CrearMovimientoBulkAsync(this.modeloBulkMovimiento);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", "Se produjo un error al crear el movimiento.", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El movimiento se ha creado correctamente.", Severity.Success);
				MudDialog.Close(DialogResult.Ok(this.modeloMovimiento));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al crear el movimiento.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel()
				{
					IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask),
					Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace,
					Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now
				});
			}
		}

		private async Task CancelarAsync()
		{
			DialogResult resultado = await this.dialogService.Show<DescartarCambios>("Descartar cambios").Result;

			if (!resultado.Cancelled)
			{
				MudDialog.Cancel();
			}
		}
	}
}