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
//     Nombre: Tecnologia.cs
//     Fecha creación: 2021/11/15 at 08:34 AM
//     Fecha modificación: 2021/11/15 at 08:34 AM
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
using ReporteriaClaro.Application.Interfaces.Services.Data;
using ReporteriaClaro.Application.Models.Input.Choice;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaClaro.Clients.BlazorServerSide.Data
{
	public class TecnologiaData
	{
		private readonly ITecnologiaEquipoService tecnologiaEquipoService;

		private readonly ILogExcepcionUsuarioService logExcepcionUsuarioService;

		private readonly NavigationManager navigationManager;

		private readonly ISnackbar snackbar;

		public TecnologiaData(ITecnologiaEquipoService tecnologiaEquipoService, ILogExcepcionUsuarioService logExcepcionUsuarioService, NavigationManager navigationManager, ISnackbar snackbar)
		{
			this.tecnologiaEquipoService = tecnologiaEquipoService;
			this.logExcepcionUsuarioService = logExcepcionUsuarioService;
			this.navigationManager = navigationManager;
			this.snackbar = snackbar;
		}

		public async Task<ChoiceTecnologiaEquipoModel[]> ObtenerListaTecnologiasAsync(Task<AuthenticationState> authenticationStateTask)
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
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(authenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return Array.Empty<ChoiceTecnologiaEquipoModel>();
			}
		}
	}
}