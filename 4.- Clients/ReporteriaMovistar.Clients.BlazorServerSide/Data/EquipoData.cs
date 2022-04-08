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
//     Nombre: Equipo.cs
//     Fecha creación: 2021/11/12 at 06:20 PM
//     Fecha modificación: 2021/11/12 at 06:21 PM
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
	public class EquipoData
	{
		private readonly IEquipoService equipoService;

		private readonly ILogExcepcionUsuarioService logExcepcionUsuarioService;

		private readonly NavigationManager navigationManager;

		private readonly ISnackbar snackbar;

		public EquipoData(IEquipoService equipoService, ILogExcepcionUsuarioService logExcepcionUsuarioService, NavigationManager navigationManager, ISnackbar snackbar)
		{
			this.equipoService = equipoService;
			this.logExcepcionUsuarioService = logExcepcionUsuarioService;
			this.navigationManager = navigationManager;
			this.snackbar = snackbar;
		}

		public async Task<IEnumerable<ChoiceEquipoModel>> BuscarEquipoAsync(string esnBuscado, Task<AuthenticationState> authenticationStateTask)
		{
			try
			{
				Result<IEnumerable<SPInformacionEquipoEntityResultDto>> resultadoEquipo = await this.equipoService.ObtenerListaEquiposAsync(esnBuscado);

				if (resultadoEquipo.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la lista de equipos.", string.Join("\r\n", resultadoEquipo.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return Array.Empty<ChoiceEquipoModel>();
				}

				return resultadoEquipo.Data.Select(c => new ChoiceEquipoModel() { Id = c.Id, Esn = c.Esn, Marca = c.Marca, Modelo = c.Modelo, Color = c.Color, IdTecnologia = c.TecnologiaId });
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar la lista de equipos.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(authenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return Array.Empty<ChoiceEquipoModel>();
			}
		}
	}
}