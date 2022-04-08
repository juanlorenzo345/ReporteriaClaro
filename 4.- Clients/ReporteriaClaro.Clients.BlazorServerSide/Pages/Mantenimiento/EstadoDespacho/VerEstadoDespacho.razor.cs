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

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.EstadoDespacho
{
    public partial class VerEstadoDespacho
    {
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewEstadoDespachoModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearEstadoAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearEstadoDespacho>("Crear estado").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarEstadoAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarEstadoDespacho.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarEstadoDespacho>("Editar estado", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarEstadoAsync(ViewEstadoDespachoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarEstadoDespacho.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarEstadoDespacho>("Eliminar estado", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewEstadoDespachoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando los estados de despacho...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<DespachoEstadoEntityDto>> resultadoEstado = await this.estadoDespachoService.ObtenerListaEstadosPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoEstado.Type != ResultType.Succeeded)
				{
					return new TableData<ViewEstadoDespachoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<DespachoEstadoEntityDto> datosEstado = resultadoEstado.Data;
				this.totalItems = datosEstado.RowCount;

				return new TableData<ViewEstadoDespachoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosEstado.Results.Select((e, i) => new ViewEstadoDespachoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = e.Id,
						Estado = e.Nombre,
						Posicion = e.Posicion,
						FechaCreacionRegistro = e.FechaCreacionRegistro,
						UsuarioCreacionRegistro = e.UsuarioCreacionRegistro,
						FechaModificacionRegistro = e.FechaModificacionRegistro,
						UsuarioModificacionRegistro = e.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = e.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = e.UsuarioEliminacionRegistro,
						Eliminado = !e.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de estados de despacho.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewEstadoDespachoModel>()
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
