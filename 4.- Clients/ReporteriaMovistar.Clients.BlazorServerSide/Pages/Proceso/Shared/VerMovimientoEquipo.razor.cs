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
//     Nombre: VerMovimientoEquipo.razor.cs
//     Fecha creación: 2021/11/09 at 10:39 AM
//     Fecha modificación: 2021/11/09 at 10:39 AM
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
using ReporteriaMovistar.Application.Models.Enums;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Pagination;
using ReporteriaMovistar.Application.Models.Sorting;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Application.Models.View;
using ReporteriaMovistar.Clients.BlazorServerSide.Extensions;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Proceso.Shared
{
	public partial class VerMovimientoEquipo
	{
		[Parameter]
		public string NombreEtapa
		{
			get;
			set;
		}

		[Parameter]
		public Etapa Etapa
		{
			get;
			set;
		}

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewMovimientoEquipoModel> tabla;

		private bool mostrarEliminados = false;

		private string esnBuscado = null;

		private int totalItems;

		public async Task RecargarDatosAsync()
		{
			await this.tabla.ReloadServerData();
		}

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

		private async Task CrearMovimientoAsync()
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(CrearMovimientoEquipo.Etapa)] = this.Etapa
			};

			DialogResult resultado = await this.dialogService.Show<CrearMovimientoEquipo>($"Crear movimiento de {this.NombreEtapa}", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarMovimientoAsync(ViewMovimientoEquipoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarMovimientoEquipo.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarMovimientoEquipo>($"Eliminar movimiento de {this.NombreEtapa}", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewMovimientoEquipoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information($"Consultado los movimientos de {this.NombreEtapa.ToLower()}...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<VWMovimientoEquipoEntityDto>> resultadoMovimiento = await this.movimientoEquipoService.ObtenerListaMovimientosPaginadoAsync(this.esnBuscado, this.Etapa, this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoMovimiento.Type != ResultType.Succeeded)
				{
					return new TableData<ViewMovimientoEquipoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<VWMovimientoEquipoEntityDto> datosMovimiento = resultadoMovimiento.Data;
				this.totalItems = datosMovimiento.RowCount;

				return new TableData<ViewMovimientoEquipoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosMovimiento.Results.Select((m, i) => new ViewMovimientoEquipoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = m.Id,
						Fecha = m.Fecha,
						Esn = m.Esn,
						Marca = m.Marca,
						Modelo = m.Modelo,
						Color = m.Color,
						Origen = m.Origen,
						Destino = m.Destino,
						Operario = m.Operario,
						OperarioDevolucion = m.OperarioDevolucion,
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
				this.snackbar.Add($"Se produjo un error al cargar los movimientos de {this.NombreEtapa.ToLower()}.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewMovimientoEquipoModel>()
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