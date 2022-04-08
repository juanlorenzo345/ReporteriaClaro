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
//     Nombre: VerMainUsuario.razor.cs
//     Fecha creación: 2021/11/05 at 01:08 PM
//     Fecha modificación: 2021/11/05 at 01:08 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaMovistar.Application.Models.View;

namespace ReporteriaMovistar.Clients.BlazorServerSide.Pages.Seguridad.Usuario
{
	public partial class VerMainUsuario
	{
		private MainUsuario vista = MainUsuario.VerUsuario;

		private ViewUsuarioModel usuario = new ViewUsuarioModel();
	}
}