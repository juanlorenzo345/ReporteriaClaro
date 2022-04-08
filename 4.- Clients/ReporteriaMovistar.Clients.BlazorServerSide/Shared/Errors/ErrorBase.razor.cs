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
//     Nombre: ErrorBase.razor.cs
//     Fecha creación: 2021/09/30 at 04:30 PM
//     Fecha modificación: 2021/09/30 at 04:30 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.AspNetCore.Components;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Shared.Errors
{
	public partial class ErrorBase
	{
		[Parameter]
		public string Mensaje
		{
			get;
			set;
		}

		[Parameter]
		public string Icono
		{
			get;
			set;
		}

		/*[Parameter]
		public Color ColorIcono
		{
			get;
			set;
		}*/
	}
}