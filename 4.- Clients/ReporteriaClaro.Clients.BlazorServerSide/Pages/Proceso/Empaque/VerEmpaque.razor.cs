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
//     Nombre: VerEmpaque.razor.cs
//     Fecha creación: 2021/11/09 at 12:02 PM
//     Fecha modificación: 2021/11/09 at 12:02 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Threading.Tasks;
using ReporteriaClaro.Clients.BlazorServerSide.Pages.Proceso.Shared;

namespace ReporteriaClaro.Clients.BlazorServerSide.Pages.Proceso.Empaque
{
	public partial class VerEmpaque
	{
		private VerMovimientoEquipo movimientoEquipo;

		private async Task RecargarDatosArchivoProcesadoAsync()
		{
			await this.movimientoEquipo.RecargarDatosAsync();
		}
	}
}