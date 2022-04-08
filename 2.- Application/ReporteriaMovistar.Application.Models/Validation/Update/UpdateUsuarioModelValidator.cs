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
//     Nombre: UpdateUsuarioModelValidator.cs
//     Fecha creación: 2021/10/27 at 02:30 PM
//     Fecha modificación: 2021/10/27 at 02:30 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Update;

namespace ReporteriaMovistar.Application.Models.Validation.Update
{
	public class UpdateUsuarioModelValidator : AbstractValidatorMudBlazorBase<UpdateUsuarioModel>
	{
		public UpdateUsuarioModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdateUsuarioModel, string>());
			RuleFor(u => u.NombreUsuario).NotEmpty().WithMessage("El nombre de usuario está vacío.").MaximumLength(256).WithMessage("El nombre de usuario no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(u => u.NombreCompleto).NotEmpty().WithMessage("El nombre completo está vacío.").MaximumLength(256).WithMessage("El nombre de usuario no puede exceder los {MaxLength} caracteres de longitud.");
			When(u => u.CambiarContrasena, () =>
			{
				RuleFor(u => u.Contrasena).NotEmpty().WithMessage("La nueva contraseña está vacía.").MinimumLength(8).WithMessage("La contraseña debe tener, al menos, {MinLength} caracteres.").Matches(ValidationPatterns.PasswordPattern).WithMessage("La nueva contraseña debe contener, al menos, una letra mayúscula, una letra minúscula, un número y un carácter no alfanumérico.");
				RuleFor(u => u.ContrasenaConfirmacion).Equal(r => r.Contrasena).WithMessage("Las contraseñas no coinciden.");
			});
		}
	}
}