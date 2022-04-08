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
// Solución/Proyecto: TsaDotNet / TsaDotNet.Clients.BlazorWasm
// Info archivo:
//     Nombre: Login.razor.cs
//     Fecha creación: 2021/09/30 at 05:09 PM
//     Fecha modificación: 2021/09/30 at 05:09 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;
using MudBlazor;
using ReporteriaMovistar.Application.Models.Input.Authentication;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Clients.BlazorServerSide.Helpers;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData;
using ReporteriaMovistar.Clients.BlazorServerSide.IdentityData.Models;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Shared.Authentication
{
	public partial class Login
	{
		private string error;

		private MudForm formulario;

		private LoginModel modelo = new LoginModel();

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask
		{
			get;
			set;
		}

		protected override async Task OnInitializedAsync()
		{
			AuthenticationState authenticationState = await this.AuthenticationStateTask;

			if (authenticationState?.User?.Identity is not null && authenticationState.User.Identity.IsAuthenticated)
			{
				this.navigationManager.NavigateTo("/", true);
			}
		}

		private async Task ValidarTeclaPresionadaAsync(KeyboardEventArgs args)
		{
			if (args.Code == "Enter" || args.Code == "NumpadEnter")
			{
				await IniciarSesionAsync();
			}
		}

		public async Task IniciarSesionAsync()
		{
			this.error = string.Empty;
			await this.formulario.Validate();

			if (!this.formulario.IsValid)
			{
				return;
			}

			this.userManager.PasswordHasher = new ApplicationPasswordHasher();
			ApplicationUser usuario = await this.userManager.FindByNameAsync(this.modelo.Usuario);

			if (usuario is null)
			{
				Log.Information("El usuario no existe.");
				this.error = "El usuario y/o la contraseña no es válida.";
				return;
			}

			switch (usuario?.Active)
			{
				case true when await this.userManager.CheckPasswordAsync(usuario, this.modelo.Contrasena):
				{
					Log.Information("Usuario inició sesión.");
					await LogAccessAsync(usuario.Id, true);
					string token = await this.userManager.GenerateUserTokenAsync(usuario, TokenOptions.DefaultProvider, "SignIn");
					string data = $"{usuario.Id}|{token}|{this.modelo.Recordarme}";
					NameValueCollection parsedQuery = System.Web.HttpUtility.ParseQueryString(new Uri(this.navigationManager.Uri).Query);
					string returnUrl = parsedQuery["returnUrl"];

					if (!string.IsNullOrWhiteSpace(returnUrl))
					{
						data += $"|{returnUrl}";
					}

					IDataProtector protector = this.dataProtectionProvider.CreateProtector("SignIn");
					string personalData = protector.Protect(data);
					this.navigationManager.NavigateTo("/account/signinactual?t=" + personalData, true);
					break;
				}
				case true when !(await this.userManager.CheckPasswordAsync(usuario, this.modelo.Contrasena)):
				{
					Log.Information("La contraseña proporcionada es incorrecta.");
					this.error = "El usuario y/o la contraseña no es válida.";
					break;
				}
				case false:
				{
					Log.Warning("Cuenta de usuario desactivada.");
					await LogAccessAsync(usuario.Id, false, "Usuario desactivado.");
					this.error = "Intento de inicio de sesión inválido.";
					break;
				}
				default:
				{
					Log.Warning("Respuesta inesperada en intento de inicio de sesión.");
					this.error = "Intento de inicio de sesión inválido.";
					break;
				}
			}
		}

		private async Task LogAccessAsync(string userId, bool successfulLogin, string detail = null)
		{
			//string ipAddress = this.httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
			string ipAddress = await this.jsRuntime.InvokeAsync<string>("getIpAddress");
			await this.logAccesoUsuarioService.CrearLogAsync(new NewLogAccesoUsuarioModel() { IdUsuario = userId, DireccionIp = ipAddress, FechaAcceso = DateTime.Now, LoginSatisfactorio = successfulLogin, Detalle = detail });
		}
	}
}