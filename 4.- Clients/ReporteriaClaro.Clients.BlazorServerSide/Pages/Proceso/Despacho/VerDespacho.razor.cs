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
//     Fecha creación: 2021/11/11 at 12:55 PM
//     Fecha modificación: 2021/11/11 at 12:55 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaClaro.Application.Models.View;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Proceso.Despacho
{
	public partial class VerDespacho
	{
		private Despacho vista = Despacho.VerEncabezadoDespacho;

		private ViewEncabezadoDespachoModel encabezadoDespacho = new ViewEncabezadoDespachoModel();

		private bool abrirAgregarDetalle = false;
	}
}