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
//     Nombre: RegisterRequestModel.cs
//     Fecha creación: 2021/10/01 at 11:56 AM
//     Fecha modificación: 2021/10/01 at 11:56 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

namespace ReporteriaClaro.Application.Models.Input.Authentication
{
	public class RegisterRequestModel
	{
		public string NombreCompleto
		{
			get;
			set;
		}

		public string NombreUsuario
		{
			get;
			set;
		}

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

		public string UsuarioCreacionRegistro
		{
			get;
			set;
		}

		public bool Activo
		{
			get => true;
		}
	}
}