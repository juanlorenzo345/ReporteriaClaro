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
//     Nombre: VerUsuarioApi.razor.cs
//     Fecha creación: 2021/11/29 at 12:21 PM
//     Fecha modificación: 2021/11/29 at 12:21 PM
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

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Seguridad.UsuarioApi
{
	public partial class VerUsuarioApi
	{
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		private MudTable<ViewUsuarioApiModel> tabla;

		private int totalItems;

		private async Task CrearUsuarioAsync()
		{
			//DialogResult resultado = await this.dialogService.Show<CrearUsuarioApi>("Crear usuario").Result;
			//HACK: Workaround para abrir otra modal https://github.com/MudBlazor/MudBlazor/issues/3101.
			IDialogReference dialogo = this.dialogService.Show<CrearUsuarioApi>("Crear usuario");
			DialogResult resultado = await dialogo.Result;

			if (!resultado.Cancelled)
			{
				this.dialogService.Close(dialogo as DialogReference);
				DialogParameters parametros = new DialogParameters()
				{
					[nameof(MostrarApiKey.ApiKey)] = (string) resultado.Data
				};
				
				await this.dialogService.Show<MostrarApiKey>("API key", parametros).Result;
				await this.tabla.ReloadServerData();
			}
		}

		private async Task EliminarUsuarioAsync(ViewUsuarioApiModel modelo)
		{
			DialogParameters parametros = new DialogParameters()
			{
				[nameof(EliminarUsuarioApi.Modelo)] = modelo
			};

			DialogResult resultado =
			await this.dialogService.Show<EliminarUsuarioApi>("Eliminar usuario", parametros).Result;

			if (!resultado.Cancelled)
			{
				await this.tabla.ReloadServerData();
			}
		}

		private async Task<TableData<ViewUsuarioApiModel>> ObtenerDatosAsync(TableState estado)
		{
			Log.Information("Consultando los usuarios de API...");

			PagerInfo infoPaginacion = new PagerInfo(estado.Page, estado.PageSize);
			SortingInfo infoOrdenamiento = new SortingInfo(estado.SortLabel, estado.SortDirection.ToSortingDirection());

			try
			{
				Result<PagedResult<ApiUserEntityDto>> resultadoUsuario =
				await this.usuarioApiService.ObtenerListaUsuariosPaginadoAsync(infoPaginacion, infoOrdenamiento);

				if (resultadoUsuario.Type != ResultType.Succeeded)
				{
					return new TableData<ViewUsuarioApiModel>()
					{
						TotalItems = 0
					};
				}

				PagedResult<ApiUserEntityDto> datosUsuario = resultadoUsuario.Data;
				this.totalItems = datosUsuario.RowCount;

				return new TableData<ViewUsuarioApiModel>()
				{
					TotalItems = this.totalItems,
					Items = datosUsuario.Results.Select((a, i) => new ViewUsuarioApiModel()
					{
						NumeroFila = (estado.PageSize * estado.Page) + i + 1,
						Id = a.Id,
						Comentario = a.Comments,
						FechaCreacionRegistro = a.CreatedAt,
						UsuarioCreacionRegistro = a.CreatedBy,
						FechaModificacionRegistro = a.ModifiedAt,
						UsuarioModificacionRegistro = a.ModifiedBy,
						FechaEliminacionRegistro = a.DeactivatedAt,
						UsuarioEliminacionRegistro = a.DeactivatedBy,
						RazonDesactivacion = a.DeactivatedReason,
						Eliminado = !a.Active
					})
				};
			}
			catch (Exception excepcion)
			{
				this.snackbar.Add("Se produjo un error al cargar la lista de usuarios de API.", Severity.Error);
				Log.Error(excepcion.ToString());
				await this.logExcepcionUsuarioService.CrearLogAsync(new NewLogExcepcionUsuarioModel()
				{
					IdUsuario = await UserInfo.GetUserIdAsync(this.AuthenticationStateTask),
					Mensaje = excepcion.Message, Tipo = excepcion.GetType().Name, Origen = excepcion.StackTrace,
					Url = this.navigationManager.Uri, FechaCreacionRegistro = DateTime.Now
				});
				return new TableData<ViewUsuarioApiModel>()
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