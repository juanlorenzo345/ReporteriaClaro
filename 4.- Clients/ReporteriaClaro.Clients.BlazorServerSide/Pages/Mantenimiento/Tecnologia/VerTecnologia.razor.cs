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
//     Nombre: VerTecnologia.razor.cs
//     Fecha creación: 2021/11/03 at 03:54 PM
//     Fecha modificación: 2021/11/03 at 03:55 PM
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
using ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.Zona;
using Serilog;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Mantenimiento.Tecnologia
{
	public partial class VerTecnologia
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewTecnologiaEquipoModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearTecnologiaAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearTecnologia>("Crear tecnología").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarTecnologiaAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarTecnologia.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarTecnologia>("Editar tecnología", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarTecnologiaAsync(ViewTecnologiaEquipoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarTecnologia.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarTecnologia>("Eliminar tecnología", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewTecnologiaEquipoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado las tecnologías...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<EquipoTecnologiaEntityDto>> resultadoTecnologia = await this.tecnologiaEquipoService.ObtenerListaTecnologiasPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoTecnologia.Type != ResultType.Succeeded)
				{
					return new TableData<ViewTecnologiaEquipoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<EquipoTecnologiaEntityDto> datosTecnologia = resultadoTecnologia.Data;
				this.totalItems = datosTecnologia.RowCount;

				return new TableData<ViewTecnologiaEquipoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosTecnologia.Results.Select((t, i) => new ViewTecnologiaEquipoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = t.Id,
						Tecnologia = t.Nombre,
						FechaCreacionRegistro = t.FechaCreacionRegistro,
						UsuarioCreacionRegistro = t.UsuarioCreacionRegistro,
						FechaModificacionRegistro = t.FechaModificacionRegistro,
						UsuarioModificacionRegistro = t.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = t.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = t.UsuarioEliminacionRegistro,
						Eliminado = !t.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de tecnologías.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewTecnologiaEquipoModel>()
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