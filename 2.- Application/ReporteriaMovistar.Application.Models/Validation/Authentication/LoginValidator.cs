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
//     Nombre: LoginRequestValidator.cs
//     Fecha creación: 2021/10/25 at 10:32 AM
//     Fecha modificación: 2021/10/25 at 10:32 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Authentication;

namespace ReporteriaMovistar.Application.Models.Validation.Authentication
{
	public class LoginValidator : AbstractValidatorMudBlazorBase<LoginModel>
	{
		#region Constructors

		public LoginValidator()
		{
			RuleFor(l => l.Usuario).NotEmpty().WithMessage("El usuario está vacío.");
			RuleFor(l => l.Contrasena).NotEmpty().WithMessage("La contraseña está vacía.");
		}

		#endregion
	}
}