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
//     Nombre: VerZona.razor.cs
//     Fecha creación: 2021/11/02 at 08:58 AM
//     Fecha modificación: 2021/11/02 at 08:58 AM
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

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.Zona
{
	public partial class VerZona
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewZonaModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearZonaAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearZona>("Crear zona").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarZonaAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarZona.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarZona>("Editar zona", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarZonaAsync(ViewZonaModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarZona.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarZona>("Eliminar zona", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewZonaModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado las zonas...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<ZonaEntityDto>> resultadoZona = await this.zonaService.ObtenerListaZonasPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoZona.Type != ResultType.Succeeded)
				{
					return new TableData<ViewZonaModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<ZonaEntityDto> datosZona = resultadoZona.Data;
				this.totalItems = datosZona.RowCount;

				return new TableData<ViewZonaModel>()
				{
					TotalItems = this.totalItems,
					Items = datosZona.Results.Select((z, i) => new ViewZonaModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = z.Id,
						Zona = z.Nombre,
						FechaCreacionRegistro = z.FechaCreacionRegistro,
						UsuarioCreacionRegistro = z.UsuarioCreacionRegistro,
						FechaModificacionRegistro = z.FechaModificacionRegistro,
						UsuarioModificacionRegistro = z.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = z.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = z.UsuarioEliminacionRegistro,
						Eliminado = !z.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de zonas.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewZonaModel>()
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