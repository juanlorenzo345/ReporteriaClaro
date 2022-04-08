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
// Solución/Proyecto: TsaDotNet / TsaDotNet.Application.Models
// Info archivo:
//     Nombre: CurrentUserModel.cs
//     Fecha creación: 2021/10/01 at 12:42 PM
//     Fecha modificación: 2021/10/01 at 12:42 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;

namespace ReporteriaClaro.Application.Models.Input.Authentication
{
	public class UsuarioActualModel
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

		public string Rol
		{
			get;
			set;
		}

		public bool Autenticado
		{
			get;
			set;
		}

		public Dictionary<string, string> Claims
		{
			get;
			set;
		}
	}
}