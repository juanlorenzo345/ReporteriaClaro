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
//     Nombre: VerDetalleDespacho.razor.cs
//     Fecha creación: 2021/11/11 at 11:54 AM
//     Fecha modificación: 2021/11/11 at 11:54 AM
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
	public partial class VerDetalleDespacho
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
			get;
			set;
		}

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		[Parameter]
		public bool AbrirAgregarDetalle
		{
			get;
			set;
		}

		private MudTable<ViewDetalleDespachoModel> tabla;

		private bool mostrarEliminados = false;

		private int totalItems;

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			await AbrirCrearDetalleAlInicioAsync();
		}

		private async Task AbrirCrearDetalleAlInicioAsync()
		{
			if (this.AbrirAgregarDetalle)
			{
				await CrearDetalleAsync();
			}
		}

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task CrearDetalleAsync()
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(CrearDetalleDespacho.IdEncabezado)] = this.Registro.Id
			};

			DialogResult resultado = await this.dialogService.Show<CrearDetalleDespacho>("Agregar detalle", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarDetalleAsync(int id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarDetalleDespacho.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarDetalleDespacho>("Editar detalle", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarDetalleAsync(ViewDetalleDespachoModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarDetalleDespacho.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<EliminarDetalleDespacho>("Quitar detalle", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private void VolverADespacho()
		{
			this.Vista = Despacho.VerEncabezadoDespacho;
		}

		private async Task<TableData<ViewDetalleDespachoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado los detalles de despacho...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<DespachoDetalleEntityDto>> resultadoDetalle = await this.detalleDespachoService.ObtenerListaDetallesPaginadoAsync(this.Registro.Id, this.mostrarEliminados, infoPaginacion, infoOrdenamiento);

				if (resultadoDetalle.Type != ResultType.Succeeded)
				{
					return new TableData<ViewDetalleDespachoModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<DespachoDetalleEntityDto> datosDetalle = resultadoDetalle.Data;
				this.totalItems = datosDetalle.RowCount;

				return new TableData<ViewDetalleDespachoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosDetalle.Results.Select((d, i) => new ViewDetalleDespachoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = d.Id,
						Esn = d.EquipoEntity.Esn,
						Marca = d.EquipoEntity.EquipoModeloEntity.EquipoMarcaEntity.Nombre,
						Modelo = d.EquipoEntity.EquipoModeloEntity.Nombre,
						Color = d.EquipoEntity.EquipoColorEntity.Nombre,
						Pallet = d.Pallet,
						Caja = d.Caja,
						Derivada = d.EquipoEntity.Derivada,
						Pintura = d.EquipoEntity.Pintura,
						ProcesoFinalizado = d.EquipoEntity.ProcesoFinalizado,
						FuentePoder = d.EquipoEntity.ComponenteEstadoEntity_FuentePoderEstadoId?.Nombre,
						Utp = d.EquipoEntity.ComponenteEstadoEntity_UtpEstadoId?.Nombre,
						ControlRemoto = d.EquipoEntity.ComponenteEstadoEntity_ControlRemotoEstadoId?.Nombre,
						Hdmi = d.EquipoEntity.ComponenteEstadoEntity_HdmiEstadoId?.Nombre,
						Rca = d.EquipoEntity.ComponenteEstadoEntity_RcaEstadoId?.Nombre,
						FechaCreacionRegistro = d.FechaCreacionRegistro,
						UsuarioCreacionRegistro = d.UsuarioCreacionRegistro,
						FechaModificacionRegistro = d.FechaModificacionRegistro,
						UsuarioModificacionRegistro = d.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = d.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = d.UsuarioEliminacionRegistro,
						Eliminado = !d.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de detalles de despacho.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewDetalleDespachoModel>()
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