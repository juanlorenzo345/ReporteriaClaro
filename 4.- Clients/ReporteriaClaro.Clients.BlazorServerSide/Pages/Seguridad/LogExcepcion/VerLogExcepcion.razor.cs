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
//     Nombre: VerLogExcepcion.razor.cs
//     Fecha creación: 2021/11/05 at 09:53 AM
//     Fecha modificación: 2021/11/05 at 09:53 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Application.Models.View;
using ReporteriaClaro.Clients.BlazorServerSide.Extensions;
using ReporteriaClaro.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Seguridad.LogExcepcion
{
	public partial class VerLogExcepcion
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewLogExcepcionUsuarioModel> tabla;

		private int totalItems;

		private async Task<TableData<ViewLogExcepcionUsuarioModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado los log de excepciones...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<IdentityUserExceptionLogEntityDto>> resultadoLogExcepcion = await this.logExcepcionUsuarioService.ObtenerListaExcepcionesPaginadoAsync(infoPaginacion, infoOrdenamiento);

				if (resultadoLogExcepcion.Type != ResultType.Succeeded)
				{
					return new TableData<ViewLogExcepcionUsuarioModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<IdentityUserExceptionLogEntityDto> datosLogExcepcion = resultadoLogExcepcion.Data;
				this.totalItems = datosLogExcepcion.RowCount;

				return new TableData<ViewLogExcepcionUsuarioModel>()
				{
					TotalItems = this.totalItems,
					Items = datosLogExcepcion.Results.Select((l, i) => new ViewLogExcepcionUsuarioModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = l.Id,
						Usuario = l.IdentityUserEntity.UserName,
						Mensaje = l.Message,
						Tipo = l.Type,
						Origen = l.Source,
						Url = l.Url,
						FechaCreacionRegistro = l.CreatedAt
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de log de excepciones.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewLogExcepcionUsuarioModel>()
				{
					TotalItems = 0
				};
			}
			finally
			{
				StateHasChanged();
			}
		}
	}
}