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
//     Nombre: CrearSecuenciaEtapa.razor.cs
//     Fecha creación: 2021/12/06 at 12:15 PM
//     Fecha modificación: 2021/12/06 at 12:16 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ReporteriaClaro.Application.Models.Input.Choice;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using ReporteriaClaro.Clients.BlazorServerSide.Pages.Shared;
using Serilog;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.SecuenciaEtapa
{
	public partial class CrearSecuenciaEtapa
	{
		private MudForm formulario;

		private NewSecuenciaEtapaModel modelo = new NewSecuenciaEtapaModel();

		private ChoiceEtapaModel[] etapasOrigen = new ChoiceEtapaModel[] { };

		private ChoiceEtapaModel[] etapasDestino = new ChoiceEtapaModel[] { };

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
		}

		private async Task CargarListasAsync()
		{
			this.etapasOrigen = await this.etapaData.ObtenerListaEtapasAsync(this.AuthenticationStateTask);
			this.etapasDestino = this.etapasOrigen;
		}

		private async Task GuardarAsync()
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

				Result resultado = await this.secuenciaEtapaService.CrearSecuenciaAsync(modelo);

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al crear la secuencia '{this.modelo.EtapaOrigen.Nombre}' a '{this.modelo.EtapaDestino.Nombre}'.", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"La secuencia '{this.modelo.EtapaOrigen.Nombre}' a '{this.modelo.EtapaDestino.Nombre}' se ha creado correctamente.", Severity.Success);
				MudDialog.Close(DialogResult.Ok(this.modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al crear la secuencia '{this.modelo.EtapaOrigen.Nombre}' a '{this.modelo.EtapaDestino.Nombre}'.", Severity.Error);
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