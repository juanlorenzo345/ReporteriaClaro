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
//     Nombre: VerEstadoComponente.razor.cs
//     Fecha creación: 2021/11/11 at 10:38 AM
//     Fecha modificación: 2021/11/11 at 10:40 AM
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

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Mantenimiento.EstadoComponente
{
	public partial class VerEstadoComponente
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewEstadoComponenteModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearEstadoAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearEstadoComponente>("Crear estado").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarEstadoAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarEstadoComponente.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarEstadoComponente>("Editar estado", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarEstadoAsync(ViewEstadoComponenteModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarEstadoComponente.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarEstadoComponente>("Eliminar estado", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewEstadoComponenteModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando los estados de componente...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<ComponenteEstadoEntityDto>> resultadoEstado = await this.estadoComponenteService.ObtenerListaEstadosPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoEstado.Type != ResultType.Succeeded)
				{
					return new TableData<ViewEstadoComponenteModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<ComponenteEstadoEntityDto> datosEstado = resultadoEstado.Data;
				this.totalItems = datosEstado.RowCount;

				return new TableData<ViewEstadoComponenteModel>()
				{
					TotalItems = this.totalItems,
					Items = datosEstado.Results.Select((e, i) => new ViewEstadoComponenteModel()
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
				this.snackbar.Add("Se produjo un error al cargar la lista de estados de componente.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewEstadoComponenteModel>()
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