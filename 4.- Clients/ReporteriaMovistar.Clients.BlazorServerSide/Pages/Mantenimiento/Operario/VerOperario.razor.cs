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
//     Nombre: VerOperario.razor.cs
//     Fecha creación: 2021/11/17 at 11:28 AM
//     Fecha modificación: 2021/11/17 at 11:28 AM
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

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Mantenimiento.Operario
{
	public partial class VerOperario
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewOperarioModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearOperarioAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearOperario>("Crear operario").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarOperarioAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarOperario.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarOperario>("Editar operario", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarOperarioAsync(ViewOperarioModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarOperario.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarOperario>("Eliminar operario", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewOperarioModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando los operarios...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<OperarioEntityDto>> resultadoOperario = await this.operarioService.ObtenerListaOperariosPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoOperario.Type != ResultType.Succeeded)
				{
					return new TableData<ViewOperarioModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<OperarioEntityDto> datosOperario = resultadoOperario.Data;
				this.totalItems = datosOperario.RowCount;

				return new TableData<ViewOperarioModel>()
				{
					TotalItems = this.totalItems,
					Items = datosOperario.Results.Select((e, i) => new ViewOperarioModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = e.Id,
						Operario = e.Nombre,
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
				this.snackbar.Add("Se produjo un error al cargar la lista de operarios.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewOperarioModel>()
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