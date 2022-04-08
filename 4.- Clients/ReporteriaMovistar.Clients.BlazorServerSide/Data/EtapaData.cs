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
//     Nombre: EtapaData.cs
//     Fecha creación: 2021/11/15 at 09:03 AM
//     Fecha modificación: 2021/11/15 at 09:03 AM
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
using ReporteriaMovistar.Application.Models.Enums;
using ReporteriaMovistar.Application.Models.Input.Choice;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Data
{
	public class EtapaData
	{
		private readonly IEtapaService etapaService;

		private readonly ILogExcepcionUsuarioService logExcepcionUsuarioService;

		private readonly NavigationManager navigationManager;

		private readonly ISnackbar snackbar;

		public EtapaData(IEtapaService etapaService, ILogExcepcionUsuarioService logExcepcionUsuarioService, NavigationManager navigationManager, ISnackbar snackbar)
		{
			this.etapaService = etapaService;
			this.logExcepcionUsuarioService = logExcepcionUsuarioService;
			this.navigationManager = navigationManager;
			this.snackbar = snackbar;
		}

		public async Task<ChoiceEtapaModel[]> ObtenerListaEtapasDestinoAsync(Etapa etapaOrigen, Task<AuthenticationState> authenticationStateTask)
		{
			try
			{
				Result<IEnumerable<EtapaSecuenciaEntityDto>> resultadoEtapa = await this.etapaService.ObtenerListaEtapasDestinoPorOrigenAsync(etapaOrigen);

				if (resultadoEtapa.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la lista de etapas.", string.Join("\r\n", resultadoEtapa.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return Array.Empty<ChoiceEtapaModel>();
				}

				return resultadoEtapa.Data.Select(c => new ChoiceEtapaModel() { Id = c.EtapaEntity_EtapaAnteriorPosteriorId.Id, Nombre = c.EtapaEntity_EtapaAnteriorPosteriorId.Nombre, Zona = c.EtapaEntity_EtapaAnteriorPosteriorId.ZonaEntity.Nombre, EsEtapaAnterior = c.EsEtapaAnterior}).ToArray();
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar la lista de etapas.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(authenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return Array.Empty<ChoiceEtapaModel>();
			}
		}

		public async Task<ChoiceEtapaModel[]> ObtenerListaEtapasAsync(Task<AuthenticationState> authenticationStateTask)
		{
			try
			{
				Result<IEnumerable<EtapaEntityDto>> resultadoEtapa = await this.etapaService.ObtenerListaEtapasAsync();

				if (resultadoEtapa.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la lista de etapas.", string.Join("\r\n", resultadoEtapa.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return Array.Empty<ChoiceEtapaModel>();
				}

				return resultadoEtapa.Data.Select(c => new ChoiceEtapaModel() { Id = c.Id, Nombre = c.Nombre, Zona = c.ZonaEntity.Nombre }).ToArray();
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar la lista de etapas.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(authenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return Array.Empty<ChoiceEtapaModel>();
			}
		}
	}
}