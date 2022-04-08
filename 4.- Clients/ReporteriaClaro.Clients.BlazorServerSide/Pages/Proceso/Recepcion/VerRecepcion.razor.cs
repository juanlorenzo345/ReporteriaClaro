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
//     Nombre: VerRecepcion.razor.cs
//     Fecha creación: 2021/11/08 at 04:24 PM
//     Fecha modificación: 2021/11/08 at 04:24 PM
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

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Proceso.Recepcion
{
	public partial class VerRecepcion
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewRecepcionModel> tabla;

		private bool mostrarEliminados = false;

		private bool extrayendoDesdeFullstar = false;

		private string esnBuscado = null;

		private int totalItems;

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

		public async Task ExtraerDesdeFullstarAsync()
		{
			try
			{
				this.extrayendoDesdeFullstar = true;
				string usuario = await UserInfo.GetUserNameAsync(this.AuthenticationStateTask);
				Result<(int equiposComparados, int equiposInsertados, int equiposActualizados, DateTime fechaInicioRecepcion, DateTime fechaTerminoRecepcion)> resultadoMerge = await this.equipoService.EjecutarMergeEquipoFullstarAsync(DateTime.Now, usuario);

				if (resultadoMerge.Type != ResultType.Succeeded)
				{
					this.snackbar.Add($"Se produjo un error al realizar la extracción. {resultadoMerge.Errors.FirstOrDefault()}", Severity.Error);
					return;
				}

				this.snackbar.Add($"La extracción se ha realizado correctamente. Se obtuvieron {resultadoMerge.Data.equiposComparados} registro(s) entre las fechas {resultadoMerge.Data.fechaInicioRecepcion:d} y {resultadoMerge.Data.fechaTerminoRecepcion}, de los cuales se insertaron {resultadoMerge.Data.equiposInsertados} registro(s) y se actualizaron {resultadoMerge.Data.equiposActualizados} registro(s).", Severity.Success);
			}
			finally
			{
				this.extrayendoDesdeFullstar = false;
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewRecepcionModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado las recepciones...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<EquipoEntityDto>> resultadoRecepcion = await this.equipoService.ObtenerListaEquiposPaginadoAsync(this.esnBuscado, this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoRecepcion.Type != ResultType.Succeeded)
				{
					return new TableData<ViewRecepcionModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<EquipoEntityDto> datosRecepcion = resultadoRecepcion.Data;
				this.totalItems = datosRecepcion.RowCount;

				return new TableData<ViewRecepcionModel>()
				{
					TotalItems = this.totalItems,
					Items = datosRecepcion.Results.Select((r, i) => new ViewRecepcionModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = r.Id,
						Fecha = r.Fecha,
						HeaderId = r.HeaderId,
						Esn = r.Esn,
						NumeroReferencia = r.NumeroReferencia,
						Marca = r.EquipoModeloEntity.EquipoMarcaEntity.Nombre,
						Modelo = r.EquipoModeloEntity.Nombre,
						Color = r.EquipoColorEntity.Nombre,
						Tecnologia = r.EquipoModeloEntity.EquipoTecnologiaEntity?.Nombre,
						Tipo = r.Tipo,
						Subtipo = r.Subtipo,
						Categoria = r.Categoria,
						Subcategoria = r.Subcategoria,
						FechaCreacionRegistro = r.FechaCreacionRegistro,
						UsuarioCreacionRegistro = r.UsuarioCreacionRegistro,
						FechaModificacionRegistro = r.FechaModificacionRegistro,
						UsuarioModificacionRegistro = r.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = r.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = r.UsuarioEliminacionRegistro,
						Eliminado = !r.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de recepciones.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewRecepcionModel>()
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