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
//     Nombre: VerScrap.razor.cs
//     Fecha creación: 2021/11/09 at 12:09 PM
//     Fecha modificación: 2021/11/09 at 12:09 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

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
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Proceso.Scrap
{
	public partial class VerScrap
	{
		private MudTable<ViewScrapModel> tabla;

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private bool mostrarEliminados = false;

		private string esnBuscado = null;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task BuscarPorEsnAsync(string esn)
		{
			this.esnBuscado = esn;
			await this.tabla.ReloadServerData();
		}

		private async Task<TableData<ViewScrapModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando los scrap...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<VWMovimientoEquipoEntityDto>> resultadoEquipo = await this.movimientoEquipoService.ObtenerListaMovimientosScrapPaginadoAsync(this.esnBuscado, this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoEquipo.Type != ResultType.Succeeded)
				{
					return new TableData<ViewScrapModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<VWMovimientoEquipoEntityDto> datosScrap = resultadoEquipo.Data;
				this.totalItems = datosScrap.RowCount;

				return new TableData<ViewScrapModel>()
				{
					TotalItems = this.totalItems,
					Items = datosScrap.Results.Select((m, i) => new ViewScrapModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = m.Id,
						Fecha = m.Fecha,
						Esn = m.Esn,
						Marca = m.Marca,
						Modelo = m.Modelo,
						Color = m.Color,
						Origen = m.Origen,
						Operario = m.Operario,
						Observacion = m.Observacion,
						FechaCreacionRegistro = m.FechaCreacionRegistro,
						UsuarioCreacionRegistro = m.UsuarioCreacionRegistro,
						FechaModificacionRegistro = m.FechaModificacionRegistro,
						UsuarioModificacionRegistro = m.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = m.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = m.UsuarioEliminacionRegistro,
						Eliminado = !m.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de scrap.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewScrapModel>()
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