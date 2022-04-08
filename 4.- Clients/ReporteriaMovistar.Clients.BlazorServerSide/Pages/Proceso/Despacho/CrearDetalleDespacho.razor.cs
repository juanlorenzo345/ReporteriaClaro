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
//     Nombre: CrearDetalleDespacho.razor.cs
//     Fecha creación: 2021/11/11 at 12:26 PM
//     Fecha modificación: 2021/11/11 at 12:26 PM
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
using ReporteriaMovistar.Application.Models.Enums;
using ReporteriaMovistar.Application.Models.Input.Choice;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using ReporteriaMovistar.Clients.BlazorServerSide.Pages.Shared;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Proceso.Despacho
{
	public partial class CrearDetalleDespacho
	{
		private MudForm formulario;

		private NewDetalleDespachoModel modelo = new NewDetalleDespachoModel();

		private ChoiceEstadoComponenteModel[] estadosFuentePoder = new ChoiceEstadoComponenteModel[] { };

		private ChoiceEstadoComponenteModel[] estadosUtp = new ChoiceEstadoComponenteModel[] { };

		private ChoiceEstadoComponenteModel[] estadosControlRemoto = new ChoiceEstadoComponenteModel[] { };

		private ChoiceEstadoComponenteModel[] estadosHdmi = new ChoiceEstadoComponenteModel[] { };

		private ChoiceEstadoComponenteModel[] estadosRca = new ChoiceEstadoComponenteModel[] { };

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
		public int IdEncabezado
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
		}

		private async Task CargarListasAsync()
		{
			this.estadosFuentePoder = await this.estadoComponenteData.ObtenerListaEstadosAsync(this.AuthenticationStateTask);
			this.estadosUtp = this.estadosFuentePoder;
			this.estadosControlRemoto = this.estadosFuentePoder;
			this.estadosHdmi = this.estadosFuentePoder;
			this.estadosRca = this.estadosFuentePoder;
		}

		public async Task GuardarAsync()
		{
			try
			{
				ValidarTecnologia();
				this.modelo.IdEncabezado = IdEncabezado;
				this.modelo.FechaCreacionRegistro = DateTime.Now;
				this.modelo.UsuarioCreacionRegistro = await UserInfo.GetUserNameAsync(AuthenticationStateTask);
				await this.formulario.Validate();

				if (!this.formulario.IsValid)
				{
					return;
				}

				Result resultado = await this.detalleDespachoService.CrearDetalleAsync(this.modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al agregar el equipo con ESN '{this.modelo.Equipo.Esn}' al despacho actual.", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El equipo con ESN '{this.modelo.Equipo.Esn}' se ha agregado correctamente al despacho actual.", Severity.Success);
				MudDialog.Close(DialogResult.Ok(this.modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al agregar el equipo con ESN '{this.modelo.Equipo.Esn}' al despacho actual.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
		}

		private void ValidarTecnologia()
		{
			if (this.modelo.Equipo.IdTecnologia == (int) Tecnologia.IpTv)
			{
				return;
			}

			this.modelo.EstadoControlRemoto = new ChoiceEstadoComponenteModel() { Id = (int) EstadoComponente.NoAplica };
			this.modelo.EstadoHdmi = new ChoiceEstadoComponenteModel() { Id = (int) EstadoComponente.NoAplica };
			this.modelo.EstadoRca = new ChoiceEstadoComponenteModel() { Id = (int) EstadoComponente.NoAplica };
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