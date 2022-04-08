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
//     Nombre: VerLogAcceso.razor.cs
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
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Pagination;
using ReporteriaMovistar.Application.Models.Sorting;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Application.Models.View;
using ReporteriaMovistar.Clients.BlazorServerSide.Extensions;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Seguridad.LogAcceso
{
	public partial class VerLogAcceso
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewLogAccesoUsuarioModel> tabla;

		private int totalItems;

		private async Task<TableData<ViewLogAccesoUsuarioModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado los log de accesos...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<IdentityUserAccessLogEntityDto>> resultadoLogExcepcion = await this.logAccesoUsuarioService.ObtenerListaAccesosPaginadoAsync(infoPaginacion, infoOrdenamiento);

				if (resultadoLogExcepcion.Type != ResultType.Succeeded)
				{
					return new TableData<ViewLogAccesoUsuarioModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<IdentityUserAccessLogEntityDto> datosLogExcepcion = resultadoLogExcepcion.Data;
				this.totalItems = datosLogExcepcion.RowCount;

				return new TableData<ViewLogAccesoUsuarioModel>()
				{
					TotalItems = this.totalItems,
					Items = datosLogExcepcion.Results.Select((l, i) => new ViewLogAccesoUsuarioModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = l.Id,
						Usuario = l.IdentityUserEntity.UserName,
						DireccionIp = l.IpAddress,
						LoginSatisfactorio = l.SuccessfulLogin,
						Detalle = l.Detail,
						FechaCreacionRegistro = l.AccessAt
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de log de accesos.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewLogAccesoUsuarioModel>()
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