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
//     Nombre: OperarioData.cs
//     Fecha creación: 2021/11/17 at 12:30 PM
//     Fecha modificación: 2021/11/17 at 12:30 PM
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
	public class OperarioData
	{
		private readonly IOperarioService operarioService;

		private readonly ILogExcepcionUsuarioService logExcepcionUsuarioService;

		private readonly NavigationManager navigationManager;

		private readonly ISnackbar snackbar;

		public OperarioData(IOperarioService operarioService, ILogExcepcionUsuarioService logExcepcionUsuarioService, NavigationManager navigationManager, ISnackbar snackbar)
		{
			this.operarioService = operarioService;
			this.logExcepcionUsuarioService = logExcepcionUsuarioService;
			this.navigationManager = navigationManager;
			this.snackbar = snackbar;
		}

		public async Task<IEnumerable<ChoiceOperarioModel>> BuscarOperarioAsync(string operarioBuscado, Task<AuthenticationState> authenticationStateTask)
		{
			try
			{
				Result<IEnumerable<OperarioEntityDto>> resultadoOperario = await this.operarioService.ObtenerListaOperariosAsync(operarioBuscado);

				if (resultadoOperario.Type != ResultType.Succeeded)
				{
					string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la lista de operarios.", string.Join("\r\n", resultadoOperario.Errors));
					this.snackbar.Add(mensajeError, Severity.Error);
					return Array.Empty<ChoiceOperarioModel>();
				}

				return resultadoOperario.Data.Select(c => new ChoiceOperarioModel() { Id = c.Id, Nombre = c.Nombre });
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar la lista de operarios.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(authenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return Array.Empty<ChoiceOperarioModel>();
			}
		}
	}
}