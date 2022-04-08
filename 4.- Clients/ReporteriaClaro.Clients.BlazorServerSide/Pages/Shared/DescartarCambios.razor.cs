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
//     Nombre: DescartarCambios.razor.cs
//     Fecha creación: 2021/11/02 at 06:05 PM
//     Fecha modificación: 2021/11/02 at 06:07 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Shared
{
	public partial class DescartarCambios
	{
		#region Properties and Indexers

		[CascadingParameter]
		private MudDialogInstance MudDialog
		{
			get;
			set;
		}

		#endregion

		#region Methods

		protected override void OnInitialized()
		{
			base.OnInitialized();
			ConfigurarDialogo();
		}


		private void CerrarSinGuardar()
		{
			this.snackbar.Add($"Los cambios han sido descartados por el usuario.", Severity.Warning);
			this.MudDialog.Close(DialogResult.Ok(""));
		}

		private void ConfigurarDialogo()
		{
			MudDialog.Options.CloseButton = false;
			MudDialog.Options.DisableBackdropClick = true;
			MudDialog.Options.Position = DialogPosition.Center;
			MudDialog.SetOptions(MudDialog.Options);
		}

		private void NoCerrar()
		{
			this.MudDialog.Cancel();
		}

		#endregion
	}
}