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
//     Nombre: NewUsuarioModelValidator.cs
//     Fecha creación: 2021/10/27 at 08:34 AM
//     Fecha modificación: 2021/10/27 at 08:34 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Insert;

namespace ReporteriaMovistar.Application.Models.Validation.Insert
{
	public class NewUsuarioModelValidator : AbstractValidatorMudBlazorBase<NewUsuarioModel>
	{
		#region Constructors

		public NewUsuarioModelValidator()
		{
			Include(new NewModelValidatorBase<NewUsuarioModel>());
			RuleFor(u => u.NombreUsuario).NotEmpty().WithMessage("El nombre de usuario está vacío.").MaximumLength(256).WithMessage("El nombre de usuario no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(u => u.NombreCompleto).NotEmpty().WithMessage("El nombre completo está vacío.").MaximumLength(256).WithMessage("El nombre de usuario no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(u => u.Contrasena).NotEmpty().WithMessage("La contraseña está vacía.").MinimumLength(8).WithMessage("La contraseña debe tener, al menos, {MinLength} caracteres.").Matches(ValidationPatterns.PasswordPattern).WithMessage("La contraseña debe contener, al menos, una letra mayúscula, una letra minúscula, un número y un carácter no alfanumérico.");
			RuleFor(u => u.ContrasenaConfirmacion).Equal(r => r.Contrasena).WithMessage("Las contraseñas no coinciden.");
			RuleFor(u => u.Rol.Id).NotEmpty().WithMessage("El rol está vacío.");
		}

		#endregion
	}
}