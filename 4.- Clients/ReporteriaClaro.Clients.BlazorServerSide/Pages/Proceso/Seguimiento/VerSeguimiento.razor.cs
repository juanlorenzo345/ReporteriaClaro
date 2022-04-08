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
//     Nombre: VerHistorialMovimiento.razor.cs
//     Fecha creación: 2021/11/17 at 09:33 AM
//     Fecha modificación: 2021/11/17 at 09:33 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
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

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Proceso.Seguimiento
{
	public partial class VerSeguimiento
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewSeguimientoMovimientoEquipoModel> tabla;

		private ViewSeguimientoEquipoModel modeloEquipo = new ViewSeguimientoEquipoModel();

		private ViewSeguimientoUltimoMovimientoModel modeloMovimiento = new ViewSeguimientoUltimoMovimientoModel();

		private ViewSeguimientoDespachoModel modeloDespacho = new ViewSeguimientoDespachoModel();

		private bool mostrarEliminados = false;

		private string esnBuscado = null;

		private MudTextField<string> textFieldEsn;

		private int totalItems;

		private async Task MostrarEliminadosChangedAsync()
		{
			this.mostrarEliminados = !this.mostrarEliminados;
			await this.tabla.ReloadServerData();
		}

		private async Task ValidarTeclaPresionadaAsync(KeyboardEventArgs args)
		{
			if (args.Code == "Enter" || args.Code == "NumpadEnter")
			{
				await BuscarPorEsnAsync();
			}
		}

		private async Task BuscarPorEsnAsync()
		{
			await ObtenerInformacionEquipoAsync();
			await ObtenerInformacionUltimoMovimientoAsync();
			await ObtenerInformacionDespachoAsync();
			await this.tabla.ReloadServerData();
			await this.textFieldEsn.Clear();
			await this.textFieldEsn.FocusAsync();
		}

		private async Task ObtenerInformacionEquipoAsync()
		{
			Result<SPSeguimientoEquipoEntityResultDto> resultado = await this.movimientoEquipoService.ObtenerSeguimientoEquipoAsync(this.esnBuscado);

			if (resultado.Type != ResultType.Succeeded)
			{
				string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la información de equipo.", string.Join("\r\n", resultado.Errors));
				this.snackbar.Add(mensajeError, Severity.Error);
				return;
			}

			if (resultado.Data is null)
			{
				this.modeloEquipo = new ViewSeguimientoEquipoModel();
				return;
			}

			SPSeguimientoEquipoEntityResultDto dto = resultado.Data;
			this.modeloEquipo.Fecha = dto.FechaRecepcion;
			this.modeloEquipo.Esn = dto.Esn;
			this.modeloEquipo.Marca = dto.Marca;
			this.modeloEquipo.Modelo = dto.Modelo;
			this.modeloEquipo.Color = dto.Color;
			this.modeloEquipo.Tecnologia = dto.Tecnologia;
			this.modeloEquipo.Configuracion = dto.Configuracion;
			this.modeloEquipo.DetalleConfiguracion = dto.DetalleConfiguracion;
		}

		private async Task ObtenerInformacionUltimoMovimientoAsync()
		{
			Result<SPSeguimientoUltimoMovimientoEntityResultDto> resultado = await this.movimientoEquipoService.ObtenerSeguimientoUltimoMovimientoAsync(this.esnBuscado);

			if (resultado.Type != ResultType.Succeeded)
			{
				string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la información de último movimiento.", string.Join("\r\n", resultado.Errors));
				this.snackbar.Add(mensajeError, Severity.Error);
				return;
			}

			if (resultado.Data is null)
			{
				this.modeloMovimiento = new ViewSeguimientoUltimoMovimientoModel();
				return;
			}

			SPSeguimientoUltimoMovimientoEntityResultDto dto = resultado.Data;
			this.modeloMovimiento.Fecha = dto.Fecha;
			this.modeloMovimiento.Origen = dto.Origen;
			this.modeloMovimiento.Destino = dto.Destino;
			this.modeloMovimiento.Operario = dto.Operario;
			this.modeloMovimiento.OperarioDevolucion = dto.OperarioDevolucion;
			this.modeloMovimiento.Observacion = dto.Observacion;
		}

		private async Task ObtenerInformacionDespachoAsync()
		{
			Result<SPSeguimientoDespachoEntityResultDto> resultado = await this.movimientoEquipoService.ObtenerSeguimientoDespachoAsync(this.esnBuscado);

			if (resultado.Type != ResultType.Succeeded)
			{
				string mensajeError = string.Join("\r\n", "Se produjo un error al cargar la información de despacho.", string.Join("\r\n", resultado.Errors));
				this.snackbar.Add(mensajeError, Severity.Error);
				return;
			}

			if (resultado.Data is null)
			{
				this.modeloDespacho = new ViewSeguimientoDespachoModel();
				return;
			}

			SPSeguimientoDespachoEntityResultDto dto = resultado.Data;
			this.modeloDespacho.Fecha = dto.Fecha;
			this.modeloDespacho.Guia = dto.Guia;
			this.modeloDespacho.EstadoDespacho = dto.EstadoDespacho;
			this.modeloDespacho.Caja = dto.Caja;
			this.modeloDespacho.Pallet = dto.Pallet;
			this.modeloDespacho.Derivada = dto.Derivada;
			this.modeloDespacho.EstadoUtp = dto.EstadoUtp;
			this.modeloDespacho.EstadoFuentePoder = dto.EstadoFuentePoder;
			this.modeloDespacho.EstadoControlRemoto = dto.EstadoControlRemoto;
			this.modeloDespacho.EstadoHdmi = dto.EstadoHdmi;
			this.modeloDespacho.EstadoRca = dto.EstadoRca;
			this.modeloDespacho.Pintura = dto.Pintura;
			this.modeloDespacho.ProcesoFinalizado = dto.ProcesoFinalizado;
		}

		private async Task<TableData<ViewSeguimientoMovimientoEquipoModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information($"Consultado el seguimiento de {this.esnBuscado}...");

			try
			{
				Result<IEnumerable<VWMovimientoEquipoEntityDto>> resultadoMovimiento = await this.movimientoEquipoService.ObtenerListaMovimientosPorEsnPaginadoAsync(this.esnBuscado, this.mostrarEliminados);

				if (resultadoMovimiento.Type != ResultType.Succeeded)
				{
					return new TableData<ViewSeguimientoMovimientoEquipoModel>()
					{
						TotalItems = 0
					};
				}

				List<VWMovimientoEquipoEntityDto> datosMovimiento = resultadoMovimiento.Data.ToList();
				this.totalItems = datosMovimiento.Count;

				return new TableData<ViewSeguimientoMovimientoEquipoModel>()
				{
					TotalItems = this.totalItems,
					Items = datosMovimiento.Select((m, i) => new ViewSeguimientoMovimientoEquipoModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = m.Id,
						Fecha = m.Fecha,
						Origen = m.Origen,
						Destino = m.Destino,
						Operario = m.Operario,
						OperarioDevolucion = m.OperarioDevolucion,
						Observacion = m.Observacion,
						FechaCreacionRegistro = m.FechaCreacionRegistro,
						UsuarioCreacionRegistro = m.UsuarioCreacionRegistro,
						FechaModificacionRegistro = m.FechaModificacionRegistro,
						UsuarioModificacionRegistro = m.UsuarioModificacionRegistro,
						FechaEliminacionRegistro = m.FechaEliminacionRegistro,
						UsuarioEliminacionRegistro = m.UsuarioEliminacionRegistro,
						Eliminado = !m.Activo
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar el seguimiento de {this.esnBuscado}.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewSeguimientoMovimientoEquipoModel>()
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