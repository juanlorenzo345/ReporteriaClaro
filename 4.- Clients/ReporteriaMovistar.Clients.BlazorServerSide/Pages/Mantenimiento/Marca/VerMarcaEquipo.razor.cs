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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Mantenimiento.Marca
{
    public partial class VerMarcaEquipo
    {
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewMarcaEquipoModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearMarcaAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearMarcaEquipo>("Crear marca").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarMarcaAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarMarcaEquipo.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarMarcaEquipo>("Editar marca", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarMarcaAsync(ViewMarcaEquipoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarMarcaEquipo.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarMarcaEquipo>("Eliminar marca", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewMarcaEquipoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando las marcas de equipo...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<EquipoMarcaEntityDto>> resultadoMarca = await this.marcaEquipoService.ObtenerListaMarcasPaginadosAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoMarca.Type != ResultType.Succeeded)
				{
					return new TableData<ViewMarcaEquipoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<EquipoMarcaEntityDto> datosColor = resultadoMarca.Data;
				this.totalItems = datosColor.RowCount;

				return new TableData<ViewMarcaEquipoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosColor.Results.Select((m, i) => new ViewMarcaEquipoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = m.Id,
						Marca = m.Nombre,
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
				this.snackbar.Add("Se produjo un error al cargar la lista de marcas de equipo.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewMarcaEquipoModel>()
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
