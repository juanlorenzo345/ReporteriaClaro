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
//     Nombre: VerRolUsuario.razor.cs
//     Fecha creación: 2021/11/05 at 12:24 PM
//     Fecha modificación: 2021/11/05 at 12:24 PM
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

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Seguridad.Usuario
{
	public partial class VerRolUsuario
	{
		[Parameter]
		public ViewUsuarioModel Usuario
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
		public MainUsuario Vista
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

		private MainUsuario vista;

		[Parameter]
		public EventCallback<MainUsuario> VistaChanged
		{
			get;
			set;
		}

		private MudTable<ViewRolUsuarioModel> tabla;

		private int totalItems;

		private async Task CrearRolUsuarioAsync()
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(CrearRolUsuario.IdUsuario)] = this.Usuario.Id
			};

			DialogResult resultado = await this.dialogService.Show<CrearRolUsuario>("Asignar rol", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarRolUsuarioAsync(ViewRolUsuarioModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarRolUsuario.Modelo)] = modelo,
				[nameof(EliminarRolUsuario.IdUsuario)] = this.Usuario.Id
			};

			DialogResult resultado = await this.dialogService.Show<EliminarRolUsuario>("Quitar rol", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private void VolverAUsuario()
		{
			this.Vista = MainUsuario.VerUsuario;
		}

		private async Task<TableData<ViewRolUsuarioModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information($"Consultado los roles del usuario {this.Usuario.Usuario}...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<IdentityUserRoleEntityDto>> resultadoRolUsuario = await this.rolService.ObtenerListaRolesPaginadoAsync(this.Usuario.Id, infoPaginacion, infoOrdenamiento);

				if (resultadoRolUsuario.Type != ResultType.Succeeded)
				{
					return new TableData<ViewRolUsuarioModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<IdentityUserRoleEntityDto> datosUsuario = resultadoRolUsuario.Data;
				this.totalItems = datosUsuario.RowCount;

				return new TableData<ViewRolUsuarioModel>()
				{
					TotalItems = this.totalItems,
					Items = datosUsuario.Results.Select((u, i) => new ViewRolUsuarioModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = u.RoleId,
						Rol = u.IdentityRoleEntity.Name,
						FechaCreacionRegistro = u.CreatedAt,
						UsuarioCreacionRegistro = u.CreatedBy
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add($"Se produjo un error al cargar la lista los roles del usuario {this.Usuario.Usuario}.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewRolUsuarioModel>()
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