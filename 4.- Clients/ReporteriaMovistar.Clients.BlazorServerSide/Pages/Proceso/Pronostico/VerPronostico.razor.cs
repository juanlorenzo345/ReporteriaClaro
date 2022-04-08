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
//     Nombre: VerPronostico.razor.cs
//     Fecha creación: 2021/11/04 at 09:28 AM
//     Fecha modificación: 2021/11/04 at 09:28 AM
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

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Proceso.Pronostico
{
	public partial class VerPronostico
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewPronosticoModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearPronosticoAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearPronostico>("Crear pronóstico").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarPronosticoAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarPronostico.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarPronostico>("Editar pronóstico", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarPronosticoAsync(ViewPronosticoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarPronostico.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarPronostico>("Eliminar pronóstico", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewPronosticoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado los pronósticos...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<PronosticoEntityDto>> resultadoPronostico = await this.pronosticoService.ObtenerListaPronosticosPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoPronostico.Type != ResultType.Succeeded)
				{
					return new TableData<ViewPronosticoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<PronosticoEntityDto> datosPronostico = resultadoPronostico.Data;
				this.totalItems = datosPronostico.RowCount;

				return new TableData<ViewPronosticoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosPronostico.Results.Select((p, i) => new ViewPronosticoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = p.Id,
						Periodo = new DateTime(p.Ano, p.Mes, 1),
						Estimacion = p.Estimacion,
						Tecnologia = p.EquipoTecnologiaEntity.Nombre,
						FechaCreacionRegistro = p.FechaCreacionRegistro,
						UsuarioCreacionRegistro = p.UsuarioCreacionRegistro,
						FechaModificacionRegistro = p.FechaModificacionRegistro,
						UsuarioModificacionRegistro = p.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = p.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = p.UsuarioEliminacionRegistro,
						Eliminado = !p.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de pronósticos.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewPronosticoModel>()
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