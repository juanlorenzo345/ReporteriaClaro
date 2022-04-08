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
//     Nombre: VerUsuario.razor.cs
//     Fecha creación: 2021/10/26 at 08:56 AM
//     Fecha modificación: 2021/10/26 at 08:56 AM
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
	public partial class VerUsuario
	{
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

		[Parameter]
		public ViewUsuarioModel Usuario
		{
			get
			{
				return this.usuario;
			}
			set
			{
				if (this.usuario != value)
				{
					this.usuario = value;
					UsuarioChanged.InvokeAsync(value);
				}
			}
		}

		[Parameter]
		public EventCallback<ViewUsuarioModel> UsuarioChanged
		{
			get;
			set;
		}

		private ViewUsuarioModel usuario;

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewUsuarioModel> tabla;

		private int totalItems;

		private string usuarioBuscado;

		private async Task CrearUsuarioAsync()
		{
			DialogResult resultado = await this.dialogService.Show<CrearUsuario>("Crear usuario").Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EditarUsuarioAsync(string id)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EditarUsuario.Id)] = id
			};

			DialogResult resultado = await this.dialogService.Show<EditarUsuario>("Editar usuario", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task DesactivarUsuarioAsync(ViewUsuarioModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(DesactivarUsuario.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<DesactivarUsuario>("Desactivar usuario", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task ActivarUsuarioAsync(ViewUsuarioModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(ActivarUsuario.Modelo)] = modelo
			};

			DialogResult resultado = await this.dialogService.Show<ActivarUsuario>("Activar usuario", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private void IrARolesUsuario(ViewUsuarioModel modelo)
		{
			this.Usuario = modelo;
			this.Vista = MainUsuario.VerRolUsuario;
		}

		private async Task BuscarPorUsuarioAsync(string texto)
		{
			this.usuarioBuscado = texto;
			await this.tabla.ReloadServerData();
		}

		private async Task<TableData<ViewUsuarioModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultado los usuarios...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<IdentityUserEntityDto>> resultadoUsuario = await this.usuarioService.ObtenerListaUsuariosPaginadoAsync(this.usuarioBuscado, infoPaginacion, infoOrdenamiento);

				if (resultadoUsuario.Type != ResultType.Succeeded)
				{
					return new TableData<ViewUsuarioModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<IdentityUserEntityDto> datosUsuario = resultadoUsuario.Data;
				this.totalItems = datosUsuario.RowCount;

				return new TableData<ViewUsuarioModel>()
				{
					TotalItems = this.totalItems,
					Items = datosUsuario.Results.Select((u, i) => new ViewUsuarioModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = u.Id,
						Usuario = u.UserName,
						Nombre = u.FullName,
						FechaCreacionRegistro = u.CreatedAt,
						UsuarioCreacionRegistro = u.CreatedBy,
						FechaModificacionRegistro = u.ModifiedAt,
						UsuarioModificacionRegistro = u.ModifiedBy,
						FechaEliminacionRegistro = u.DeactivatedAt,
						UsuarioEliminacionRegistro = u.DeactivatedBy,
						Activo = u.Active,
						RazonDesactivacion = u.Reason
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de usuarios.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel() { IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask), Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace, Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now });
				return new TableData<ViewUsuarioModel>()
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