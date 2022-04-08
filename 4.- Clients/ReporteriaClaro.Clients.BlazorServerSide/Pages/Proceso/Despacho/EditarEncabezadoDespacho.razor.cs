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
//     Nombre: EditarDespacho.razor.cs
//     Fecha creación: 2021/11/11 at 12:21 PM
//     Fecha modificación: 2021/11/11 at 12:21 PM
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
	public partial class EditarEncabezadoDespacho
	{
		private MudForm formulario;

		private UpdateEncabezadoDespachoModel modelo = new UpdateEncabezadoDespachoModel();

		private ChoiceEstadoDespachoModel[] estados = new ChoiceEstadoDespachoModel[] { };

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
			this.estados = await this.estadoDespachoData.ObtenerListaEstadosAsync(this.AuthenticationStateTask);
		}

		private async Task CargarDatosAsync()
		{
			Result<DespachoEncabezadoEntityDto> resultadoEncabezado = await this.encabezadoDespachoService.ObtenerEncabezadoPorIdAsync(Id);

			if (resultadoEncabezado.Type != ResultType.Succeeded)
			{
				this.snackbar.Add($"Se produjo un error al cargar los datos del despacho. {string.Join("\r\n", resultadoEncabezado.Errors)}", Severity.Error);
				MudDialog.Cancel();
				return;
			}

			DespachoEncabezadoEntityDto dto = resultadoEncabezado.Data;
			this.modelo.Id = dto.Id;
			this.modelo.Fecha = dto.Fecha;
			this.modelo.Guia = dto.Guia;
			this.modelo.Estado = new ChoiceEstadoDespachoModel() { Id = dto.DespachoEstadoEntity.Id, Nombre = dto.DespachoEstadoEntity.Nombre };
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

				Result resultado = await this.encabezadoDespachoService.ModificarEncabezadoAsync(this.modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al modificar el despacho '{this.modelo.Guia}' (ID {this.Id}).", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El despacho '{this.modelo.Guia}' se ha modificado correctamente (ID {this.Id}).", Severity.Success);
				MudDialog.Close(DialogResult.Ok(this.modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al modificar el despacho '{this.modelo.Guia}' (ID {this.Id}).", Severity.Error);
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