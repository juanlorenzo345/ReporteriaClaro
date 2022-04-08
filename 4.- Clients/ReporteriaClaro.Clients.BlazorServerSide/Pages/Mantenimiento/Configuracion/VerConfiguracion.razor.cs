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
//     Nombre: VerConfiguracion.razor.cs
//     Fecha creación: 2021/11/08 at 03:35 PM
//     Fecha modificación: 2021/11/08 at 03:35 PM
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

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.Configuracion
{
	public partial class VerConfiguracion
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewConfiguracionEquipoModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearConfiguracionAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearConfiguracion>("Crear configuración").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarConfiguracionAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarConfiguracion.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarConfiguracion>("Editar configuración", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarConfiguracionAsync(ViewConfiguracionEquipoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarConfiguracion.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarConfiguracion>("Eliminar configuración", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewConfiguracionEquipoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado las configuraciones de equipo...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<EquipoConfiguracionEntityDto>> resultadoConfiguracion = await this.configuracionEquipoService.ObtenerListaConfiguracionesPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoConfiguracion.Type != ResultType.Succeeded)
				{
					return new TableData<ViewConfiguracionEquipoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<EquipoConfiguracionEntityDto> datosConfiguracion = resultadoConfiguracion.Data;
				this.totalItems = datosConfiguracion.RowCount;

				return new TableData<ViewConfiguracionEquipoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosConfiguracion.Results.Select((c, i) => new ViewConfiguracionEquipoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = c.Id,
						Configuracion = c.Nombre,
						Detalle = c.Detalle,
						Tecnologia = c.EquipoTecnologiaEntity.Nombre,
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
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de configuraciones de equipo.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewConfiguracionEquipoModel>()
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