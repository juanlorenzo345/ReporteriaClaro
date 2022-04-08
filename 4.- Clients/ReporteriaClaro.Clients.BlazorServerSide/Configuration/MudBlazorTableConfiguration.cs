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
//     Nombre: MudBlazorTableConfiguration.cs
//     Fecha creación: 2021/10/25 at 09:17 AM
//     Fecha modificación: 2021/11/03 at 11:11 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Clients.BlazorServerSide.Configuration
{
	internal static class MudBlazorTableConfiguration
	{
		#region Fields

		internal const bool Bordered = false;

		internal const bool Dense = true;

		internal const bool FixedFooter = false;

		internal const bool FixedHeader = false;

		internal const string Height = "";

		internal const bool Hover = true;

		internal const string InfoFormat = "{first_item}-{last_item} de {all_items}";

		internal const string LoadingContentMessage = "Buscando...";

		internal const string NoRecordsContentMessage = "No hay datos que mostrar aquí.";

		internal const string RowsPerPageString = "Filas por página: ";

		internal const bool Striped = true;

		#endregion

		#region Properties and Indexers

		internal static int[] PageSizeOptions => new int[] { 10, 25, 50, 100 };

		#endregion
	}
}