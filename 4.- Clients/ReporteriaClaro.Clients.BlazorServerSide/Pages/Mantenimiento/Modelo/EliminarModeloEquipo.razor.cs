﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.View;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.Modelo
{
    public partial class EliminarModeloEquipo
    {
		#region Properties and Indexers

		[Parameter] 
		public ViewModeloEquipoModel Modelo
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
				Result resultado = await this.modeloEquipoService.EliminarModeloAsync(
				new DeleteModelBase<int>()
				{
					Id = Modelo.Id,
					FechaEliminacionRegistro = DateTime.Now,
					UsuarioEliminacionRegistro = await UserInfo.GetUserNameAsync(AuthenticationStateTask)
				});

				if (resultado.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", $"Se produjo un error al eliminar el modelo '{this.Modelo.Modelo}' (ID {this.Modelo.Id}).", string.Join("\r\n", resultado.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return;
				}

				this.snackbar.Add($"El modelo '{this.Modelo.Modelo}' se ha eliminado correctamente (ID {this.Modelo.Id}).", Severity.Success);
				this.MudDialog.Close(DialogResult.Ok(Modelo));
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al eliminar el modelo '{this.Modelo.Modelo}' (ID {this.Modelo.Id}).", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
		}

		#endregion
	}
}
