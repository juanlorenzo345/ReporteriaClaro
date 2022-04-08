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
//     Nombre: ProgresoIndefinido.razor.cs
//     Fecha creación: 2021/11/16 at 03:42 PM
//     Fecha modificación: 2021/11/16 at 03:46 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.AspNetCore.Components;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Shared
{
	public partial class ProgresoIndefinido
	{
		#region Properties and Indexers

		[Parameter]
		public string Texto
		{
			get;
			set;
		}

		[Parameter]
		public bool Visible
		{
			get;
			set;
		}

		#endregion
	}
}