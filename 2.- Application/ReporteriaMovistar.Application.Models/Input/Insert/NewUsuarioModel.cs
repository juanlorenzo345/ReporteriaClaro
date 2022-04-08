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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Application.Models
// Info archivo:
//     Nombre: NewUsuarioModel.cs
//     Fecha creación: 2021/10/27 at 08:34 AM
//     Fecha modificación: 2021/10/27 at 08:34 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaMovistar.Application.Models.Input.Choice;

namespace ReporteriaMovistar.Application.Models.Input.Insert
{
	public class NewUsuarioModel : NewModelBase
	{
		public string NombreUsuario
		{
			get;
			set;
		}

		public string NombreCompleto
		{
			get;
			set;
		}

		public ChoiceRolModel Rol
		{
			get;
			set;
		} = new ChoiceRolModel() { Id = string.Empty, Nombre = string.Empty };

		public string Contrasena
		{
			get;
			set;
		}

		public string ContrasenaConfirmacion
		{
			get;
			set;
		}
	}
}