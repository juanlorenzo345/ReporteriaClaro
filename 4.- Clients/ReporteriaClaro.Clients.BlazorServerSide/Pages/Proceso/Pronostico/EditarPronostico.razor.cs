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
//     Nombre: EditarPronostico.razor.cs
//     Fecha creación: 2021/11/04 at 09:29 AM
//     Fecha modificación: 2021/11/04 at 09:29 AM
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

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Proceso.Pronostico
{
	public partial class EditarPronostico
	{
		private MudForm formulario;

		private UpdatePronosticoModel modelo = new UpdatePronosticoModel();

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
			this.tecnologias = await ObtenerListaTecnologiasAsync();
		}

		private async Task CargarDatosAsync()
		{
			Result<PronosticoEntityDto> resultadoPronostico = await this.pronosticoService.ObtenerPronosticoPorIdAsync(Id);

			if (resultadoPronostico.Type != ResultType.Succeeded)
			{
				this.snackbar.Add($"Se produjo un error al cargar los datos del pronóstico. {string.Join("\r\n", resultadoPronostico.Errors)}", Severity.Error);
				MudDialog.Cancel();
				return;
			}

			PronosticoEntityDto dto = resultadoPronostico.Data;
			this.modelo.Id = dto.Id;
			this.modelo.Periodo = new DateTime(dto.Ano, dto.Mes, 1);
			this.modelo.Tecnologia = new ChoiceTecnologiaEquipoModel() { Id = dto.EquipoTecnologiaEntity.Id, Nombre = dto.EquipoTecnologiaEntity.Nombre };
			this.modelo.Estimacion = dto.Estimacion;
		}

		private async Task<ChoiceTecnologiaEquipoModel[]> ObtenerListaTecnologiasAsync()
		{
			try
			{
				Result<IEnumerable<EquipoTecnologiaEntityDto>> resultadoTecnologia = await this.tecnologiaEquipoService.ObtenerListaTecnologiasAsync();

				if (resultadoTecnologia.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la lista de tecnologías.", string.Join("\r\n", resultadoTecnologia.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return Array.Empty<ChoiceTecnologiaEquipoModel>();
				}

				return resultadoTecnologia.Data.Select(c => new ChoiceTecnologiaEquipoModel() { Id = c.Id, Nombre = c.Nombre }).ToArray();
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar la lista de tecnologías.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return Array.Empty<ChoiceTecnologiaEquipoModel>();
			}
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

				Result resultado = await this.pronosticoService.ModificarPronosticoAsync(this.modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n",
					$"Se produjo un error al modificar el pronóstico de '{this.modelo.Tecnologia.Nombre}' para el período {this.modelo.Periodo:MMMM yyyy} (ID {this.Id}).",
					string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El pronóstico de '{this.modelo.Tecnologia.Nombre}' para el período {this.modelo.Periodo:MMMM yyyy} se ha modificado correctamente (ID {this.Id}).", Severity.Success);
				MudDialog.Close(DialogResult.Ok(this.modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al modificar el pronóstico de '{this.modelo.Tecnologia.Nombre}' para el período {this.modelo.Periodo:MMMM yyyy} (ID {this.Id}).", Severity.Error);
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