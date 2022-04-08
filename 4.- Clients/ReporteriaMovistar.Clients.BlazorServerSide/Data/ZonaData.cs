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
//     Nombre: ZonaData.cs
//     Fecha creación: 2021/11/15 at 08:48 AM
//     Fecha modificación: 2021/11/15 at 08:48 AM
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
using ReporteriaMovistar.Application.Interfaces.Services.Data;
using ReporteriaMovistar.Application.Models.Input.Choice;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Data
{
	public class ZonaData
	{
		private readonly IZonaService zonaService;

		private readonly ILogExcepcionUsuarioService logExcepcionUsuarioService;

		private readonly NavigationManager navigationManager;

		private readonly ISnackbar snackbar;

		public ZonaData(IZonaService zonaService, ILogExcepcionUsuarioService logExcepcionUsuarioService, NavigationManager navigationManager, ISnackbar snackbar)
		{
			this.zonaService = zonaService;
			this.logExcepcionUsuarioService = logExcepcionUsuarioService;
			this.navigationManager = navigationManager;
			this.snackbar = snackbar;
		}

		public async Task<ChoiceZonaModel[]> ObtenerListaZonasAsync(Task<AuthenticationState> authenticationStateTask)
		{
			try
			{
				Result<IEnumerable<ZonaEntityDto>> resultadoZona = await this.zonaService.ObtenerListaZonasAsync();

				if (resultadoZona.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la lista de zonas.", string.Join("\r\n", resultadoZona.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return Array.Empty<ChoiceZonaModel>();
				}

				return resultadoZona.Data.Select(c => new ChoiceZonaModel() { Id = c.Id, Nombre = c.Nombre }).ToArray();
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar la lista de zonas.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(authenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return Array.Empty<ChoiceZonaModel>();
			}
		}
	}
}