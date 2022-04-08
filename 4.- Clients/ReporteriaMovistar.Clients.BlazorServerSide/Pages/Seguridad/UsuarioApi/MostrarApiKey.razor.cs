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
//     Nombre: MostrarApiKey.razor.cs
//     Fecha creación: 2021/11/29 at 04:17 PM
//     Fecha modificación: 2021/11/29 at 04:17 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Seguridad.UsuarioApi
{
	public partial class MostrarApiKey
	{
		[CascadingParameter]
		private MudDialogInstance MudDialog
		{
			get;
			set;
		}

		[Parameter]
		public string ApiKey
		{
			get;
			set;
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			ConfigurarDialogo();
		}

		private void ConfigurarDialogo()
		{
			this.MudDialog.Options.CloseButton = false;
			this.MudDialog.Options.DisableBackdropClick = true;
			this.MudDialog.Options.Position = DialogPosition.Center;
			this.MudDialog.Options.MaxWidth = MaxWidth.Medium;
			this.MudDialog.SetOptions(this.MudDialog.Options);
		}

		private async Task CopiarAlPortapapelesAsync()
		{
			await this.jsRuntime.InvokeVoidAsync("clipboardCopy.copyText", this.ApiKey);
		}

		private void Ok()
		{
			this.MudDialog.Close(DialogResult.Ok(""));
		}
	}
}