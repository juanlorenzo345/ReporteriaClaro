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
//     Nombre: VerSecuenciaEtapa.razor.cs
//     Fecha creación: 2021/12/06 at 12:15 PM
//     Fecha modificación: 2021/12/06 at 12:15 PM
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

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Mantenimiento.SecuenciaEtapa
{
	public partial class VerSecuenciaEtapa
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewSecuenciaEtapaModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearSecuenciaAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearSecuenciaEtapa>("Crear secuencia").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		/*private async Task EditarSecuenciaAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarSecuenciaEtapa.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarSecuenciaEtapa>("Editar secuencia", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}*/

		private async Task EliminarSecuenciaAsync(ViewSecuenciaEtapaModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarSecuenciaEtapa.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarSecuenciaEtapa>("Eliminar secuencia", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewSecuenciaEtapaModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando las secuencias de etapa...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<EtapaSecuenciaEntityDto>> resultadoSecuencia = await this.secuenciaEtapaService.ObtenerListaSecuenciasPaginadoAsync(this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoSecuencia.Type != ResultType.Succeeded)
				{
					return new TableData<ViewSecuenciaEtapaModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<EtapaSecuenciaEntityDto> datosSecuencia = resultadoSecuencia.Data;
				this.totalItems = datosSecuencia.RowCount;

				return new TableData<ViewSecuenciaEtapaModel>()
				{
					TotalItems = this.totalItems,
					Items = datosSecuencia.Results.Select((s, i) => new ViewSecuenciaEtapaModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = s.Id,
						EtapaOrigen = s.EtapaEntity_EtapaId.Nombre,
						EtapaDestino = s.EtapaEntity_EtapaAnteriorPosteriorId.Nombre,
						EsEtapaAnterior = s.EsEtapaAnterior,
						FechaCreacionRegistro = s.FechaCreacionRegistro,
						UsuarioCreacionRegistro = s.UsuarioCreacionRegistro,
						FechaModificacionRegistro = s.FechaModificacionRegistro,
						UsuarioModificacionRegistro = s.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = s.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = s.UsuarioEliminacionRegistro,
						Eliminado = !s.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de secuencias de etapa.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewSecuenciaEtapaModel>()
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