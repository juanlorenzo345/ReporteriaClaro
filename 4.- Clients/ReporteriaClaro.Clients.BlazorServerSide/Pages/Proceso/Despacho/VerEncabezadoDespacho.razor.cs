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
//     Nombre: VerDespacho.razor.cs
//     Fecha creación: 2021/11/09 at 12:04 PM
//     Fecha modificación: 2021/11/09 at 12:04 PM
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

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Proceso.Despacho
{
	public partial class VerEncabezadoDespacho
	{
		[Parameter]
		public Despacho Vista
		{
			get
			{
				return this.vista;
			}
			set
			{
				if (this.vista != value)
				{
					this.vista = value;
					VistaChanged.InvokeAsync(value);
				}
			}
		}

		private Despacho vista;

		[Parameter]
		public EventCallback<Despacho> VistaChanged
		{
			get;
			set;
		}

		[Parameter]
		public ViewEncabezadoDespachoModel Registro
		{
			get
			{
				return this.registro;
			}
			set
			{
				if (this.registro != value)
				{
					this.registro = value;
					RegistroChanged.InvokeAsync(value);
				}
			}
		}

		[Parameter]
		public EventCallback<ViewEncabezadoDespachoModel> RegistroChanged
		{
			get;
			set;
		}

		private ViewEncabezadoDespachoModel registro;

		[Parameter]
		public bool AbrirAgregarDetalle
		{
			get
			{
				return this.abrirAgregarDetalle;
			}
			set
			{
				if (this.abrirAgregarDetalle != value)
				{
					this.abrirAgregarDetalle = value;
					AbrirAgregarDetalleChanged.InvokeAsync(value);
				}
			}
		}

		[Parameter]
		public EventCallback<bool> AbrirAgregarDetalleChanged
		{
			get;
			set;
		}

		private bool abrirAgregarDetalle;

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewEncabezadoDespachoModel> tabla;

		private bool mostrarEliminados = false;

		private string guiaBuscado = null;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task BuscarPorGuiaAsync(string guia)
		{
			this.guiaBuscado = guia;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearEncabezadoAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearEncabezadoDespacho>("Crear despacho").Result;

			if (!resultado.Cancelled)
			{
				//await this.tabla.ReloadServerData();
				Result<DespachoEncabezadoEntityDto> resultadoEncabezado = await this.encabezadoDespachoService.ObtenerEncabezadoPorIdAsync((int) resultado.Data);

				if (resultadoEncabezado.Type == ResultType.Succeeded)
				{
					DespachoEncabezadoEntityDto datoEncabezado = resultadoEncabezado.Data;
					ViewEncabezadoDespachoModel modelo = new ViewEncabezadoDespachoModel()
					{
						NumeroFila = 1,
						Id = datoEncabezado.Id,
						Fecha = datoEncabezado.Fecha,
						Guia = datoEncabezado.Guia,
						Estado = datoEncabezado.DespachoEstadoEntity.Nombre,
						FechaCreacionRegistro = datoEncabezado.FechaCreacionRegistro,
						UsuarioCreacionRegistro = datoEncabezado.UsuarioCreacionRegistro,
						FechaModificacionRegistro = datoEncabezado.FechaModificacionRegistro,
						UsuarioModificacionRegistro = datoEncabezado.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = datoEncabezado.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = datoEncabezado.UsuarioEliminacionRegistro,
						Eliminado = !datoEncabezado.Activo
					};
					IrADetalleDespacho(modelo, true);
				}
			}
		}

		private async Task EditarEncabezadoAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarEncabezadoDespacho.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarEncabezadoDespacho>("Editar despacho", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarEncabezadoAsync(ViewEncabezadoDespachoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarEncabezadoDespacho.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarEncabezadoDespacho>("Eliminar despacho", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private void IrADetalleDespacho(ViewEncabezadoDespachoModel modelo, bool agregarDetalle)
		{
			this.Registro = modelo;
			this.AbrirAgregarDetalle = agregarDetalle;
			this.Vista = Despacho.VerDetalleDespacho;
		}

		private async Task RecargarDatosArchivoProcesadoAsync()
		{
			await this.tabla.ReloadServerData();
		}

		private async Task<TableData<ViewEncabezadoDespachoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado los encabezados de despacho...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<DespachoEncabezadoEntityDto>> resultadoEncabezado = await this.encabezadoDespachoService.ObtenerListaEncabezadosPaginadoAsync(this.guiaBuscado, this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoEncabezado.Type != ResultType.Succeeded)
				{
					return new TableData<ViewEncabezadoDespachoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<DespachoEncabezadoEntityDto> datosEncabezado = resultadoEncabezado.Data;
				this.totalItems = datosEncabezado.RowCount;

				return new TableData<ViewEncabezadoDespachoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosEncabezado.Results.Select((e, i) => new ViewEncabezadoDespachoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = e.Id,
						Fecha = e.Fecha,
						Guia = e.Guia,
						Estado = e.DespachoEstadoEntity.Nombre,
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
				this.snackbar.Add("Se produjo un error al cargar la lista de despachos.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewEncabezadoDespachoModel>()
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