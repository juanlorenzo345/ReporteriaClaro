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

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Mantenimiento.Color
{
    public partial class VerColorEquipo
    {
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewColorEquipoModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearColorAsync()
        {
			DialogResult resultado = await this.dialogService.Show<CrearColorEquipo>("Crear color").Result;

			if(!resultado.Cancelled)
            {
				await this.tabla.ReloadServerData();
            }
        }

		private async Task EditarColorAsync(int id)
        {
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarColorEquipo.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarColorEquipo>("Editar color", parametros).Result;

			if (!resultado.Cancelled)
            {
				await this.tabla.ReloadServerData();
            }
        }

		private async Task EliminarColorAsync(ViewColorEquipoModel modelo)
        {
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarColorEquipo.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarColorEquipo>("Eliminar color", parametros).Result;

			if (!resultado.Cancelled)
            {
				await this.tabla.ReloadServerData();
            }
        }

		private async Task<TableData<ViewColorEquipoModel>> ObtenerDatosAsync(TableState estado)
        {
			Log.Information("Consultando los colores de equipo...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

            try
            {
				Result<PagedResult<EquipoColorEntityDto>> resultadoColor = await this.colorEquipoService.ObtenerListaColoresPaginadoAsync(this.mostrarEliminados ,infoPaginacion, infoOrdenamiento);

				if(resultadoColor.Type != ResultType.Succeeded)
                {
					return new TableData<ViewColorEquipoModel>()
					{
						TotalItems = 0
					};
                }

				PagedResult<EquipoColorEntityDto> datosColor = resultadoColor.Data;
				this.totalItems = datosColor.RowCount;

				return new TableData<ViewColorEquipoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosColor.Results.Select((c, i) => new ViewColorEquipoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = c.Id,
						Color = c.Nombre,
						FechaCreacionRegistro = c.FechaCreacionRegistro,
						UsuarioCreacionRegistro = c.UsuarioCreacionRegistro,
						FechaModificacionRegistro = c.FechaModificacionRegistro,
						UsuarioModificacionRegistro = c.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = c.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = c.UsuarioEliminacionRegistro,
						Eliminado = !c.Activo
					})
				};
            }
            catch(Exception excepcion)
            {
				this.snackbar.Add("Se produjo un error al cargar la lista de colores de equipo.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewColorEquipoModel>()
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
