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
//     Nombre: CargaMasiva.razor.cs
//     Fecha creación: 2021/11/19 at 01:24 PM
//     Fecha modificación: 2021/11/19 at 01:24 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using ReporteriaMovistar.Application.Interfaces.Services.File;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using ReporteriaMovistar.Infrastructure.Business.File;
using ReporteriaMovistar.Infrastructure.Business.Helpers;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Shared
{
	public partial class CargaMasiva
	{
		[Parameter]
		public ICargaMasivaService CargaMasivaService
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
		public long TamanoMaximoArchivo
		{
			get;
			set;
		}

		[Parameter]
		public string Titulo
		{
			get;
			set;
		}

		[Parameter]
		public EventCallback ProcesamientoArchivoChanged
		{
			get;
			set;
		}

		#region Fields

		private IList<IBrowserFile> archivosSeleccionados = new List<IBrowserFile>();

		private bool procesandoArchivos = false;

		private string mensajeProcesandoArchivo;

		#endregion

		#region Methods

		private async Task InputFileChanged(InputFileChangeEventArgs e)
		{
			try
			{
				if (e.FileCount <= 0)
				{
					return;
				}

				this.archivosSeleccionados.Clear();
				this.archivosSeleccionados.Add(e.GetMultipleFiles(1)[0]);

				if (Path.GetExtension(this.archivosSeleccionados[0].Name) != $".{FileExtensions.Csv}")
				{
					this.snackbar.Add($"El archivo subido tiene una extensión no válida ({Path.GetExtension(this.archivosSeleccionados[0].Name)}).", Severity.Error);
					return;
				}

				if (e.File.Size > this.TamanoMaximoArchivo)
				{
					this.snackbar.Add($"El archivo subido excede el tamaño máximo permitido ({FileHelper.SizeWithSuffix(this.TamanoMaximoArchivo, 0)}).", Severity.Error);
					return;
				}

				Log.Information("Hay archivo CSV.");
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al elegir el archivo CSV.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
		}

		private async Task SubirArchivosAsync()
		{
			try
			{
				this.mensajeProcesandoArchivo = "Procesando archivo...";
				this.procesandoArchivos = true;
				await ProcesarArchivoAsync();
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al procesar el archivo CSV.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
			finally
			{
				this.procesandoArchivos = false;
				await ProcesamientoArchivoChanged.InvokeAsync();
				StateHasChanged();
			}
		}

		private async Task ProcesarArchivoAsync()
		{
			string usuario = await UserInfo.GetUserNameAsync(AuthenticationStateTask);

			await using (Stream archivo = new MemoryStream())
			{
				await this.archivosSeleccionados[0].OpenReadStream(this.TamanoMaximoArchivo).CopyToAsync(archivo);
				Result resultado = await this.CargaMasivaService.ImportarArchivoAsync(archivo, DateTime.Now, usuario);

				if (resultado.Type != ResultType.Succeeded)
				{
					this.snackbar.Add($"Se produjo un error al procesar el archivo CSV. {string.Join("\r\n", resultado.Errors)}", Severity.Error);
					return;
				}

				this.snackbar.Add($"El archivo CSV se ha procesado correctamente.", Severity.Success);
			}
		}

		private async Task DescargarEjemploArchivoAsync(MouseEventArgs e)
		{
			try
			{
				this.mensajeProcesandoArchivo = "Generando archivo...";
				this.procesandoArchivos = true;
				Result<FileResult> resultadoArchivo = await Task.Run(async () => await this.CargaMasivaService.ExportarEjemploAsync());

				if (resultadoArchivo.Type != ResultType.Succeeded)
				{
					this.snackbar.Add($"Se produjo un error al descargar el formato de ejemplo. {string.Join("\r\n", resultadoArchivo.Errors)}", Severity.Error);
					return;
				}

				await this.blazorDownloadFileService.DownloadFile(resultadoArchivo.Data.FullName, resultadoArchivo.Data.Content, DownloadContentType.Csv);
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al descargar el formato de ejemplo.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
			}
			finally
			{
				this.procesandoArchivos = false;
				StateHasChanged();
			}
		}

		#endregion
	}
}