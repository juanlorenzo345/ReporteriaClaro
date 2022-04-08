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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.Modelo
{
    public partial class VerModeloEquipo
    {
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewModeloEquipoModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearModeloAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearModeloEquipo>("Crear modelo").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarModeloAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarModeloEquipo.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarModeloEquipo>("Editar modelo", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarModeloAsync(ViewModeloEquipoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarModeloEquipo.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarModeloEquipo>("Eliminar modelo", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewModeloEquipoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando los modelos de equipo...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<EquipoModeloEntityDto>> resultadoModelo = await this.modeloEquipoService.ObtenerListaModelosPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoModelo.Type != ResultType.Succeeded)
				{
					return new TableData<ViewModeloEquipoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<EquipoModeloEntityDto> datosModelo = resultadoModelo.Data;
				this.totalItems = datosModelo.RowCount;

				return new TableData<ViewModeloEquipoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosModelo.Results.Select((m, i) => new ViewModeloEquipoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = m.Id,
						Modelo = m.Nombre,
						Marca = m.EquipoMarcaEntity.Nombre,
						Tecnologia = m.EquipoTecnologiaEntity?.Nombre,
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
				this.snackbar.Add("Se produjo un error al cargar la lista de modelos de equipos.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewModeloEquipoModel>()
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
