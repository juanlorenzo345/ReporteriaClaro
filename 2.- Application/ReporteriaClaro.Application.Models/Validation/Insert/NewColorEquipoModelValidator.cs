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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Application.Models
// Info archivo:
//     Nombre: NewColorEquipoModelValidator.cs
//     Fecha creación: 2021/10/27 at 05:30 PM
//     Fecha modificación: 2021/10/27 at 05:30 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
	public class NewColorEquipoModelValidator : AbstractValidatorMudBlazorBase<NewColorEquipoModel>
	{
		public NewColorEquipoModelValidator()
		{
			Include(new NewModelValidatorBase<NewColorEquipoModel>());
			RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(30).WithMessage("El nombre no puede exceder los {MaxLength} caracteres de longitud.");
		}
	}
}