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
//     Nombre: VerEstadoEtapa.razor.cs
//     Fecha creación: 2021/11/08 at 06:27 PM
//     Fecha modificación: 2021/11/08 at 06:27 PM
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

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.EstadoEtapa
{
	public partial class VerEstadoEtapa
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewEstadoEtapaModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearEstadoAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearEstadoEtapa>("Crear estado").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarEstadoAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarEstadoEtapa.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarEstadoEtapa>("Editar estado", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarEstadoAsync(ViewEstadoEtapaModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarEstadoEtapa.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarEstadoEtapa>("Eliminar estado", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewEstadoEtapaModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando los estados de etapa...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<EtapaEstadoEntityDto>> resultadoEstado = await this.estadoEtapaService.ObtenerListaEstadosPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoEstado.Type != ResultType.Succeeded)
				{
					return new TableData<ViewEstadoEtapaModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<EtapaEstadoEntityDto> datosEstado = resultadoEstado.Data;
				this.totalItems = datosEstado.RowCount;

				return new TableData<ViewEstadoEtapaModel>()
				{
					TotalItems = this.totalItems,
					Items = datosEstado.Results.Select((e, i) => new ViewEstadoEtapaModel()
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
				this.snackbar.Add("Se produjo un error al cargar la lista de estados de etapa.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewEstadoEtapaModel>()
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