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
//     Nombre: NewMarcaEquipoModelValidator.cs
//     Fecha creación: 2021/10/28 at 09:04 AM
//     Fecha modificación: 2021/10/28 at 09:04 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
	public class NewMarcaEquipoModelValidator : AbstractValidatorMudBlazorBase<NewMarcaEquipoModel>
	{
		public NewMarcaEquipoModelValidator()
		{
			Include(new NewModelValidatorBase<NewMarcaEquipoModel>());
			RuleFor(m => m.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(50).WithMessage("El nombre no puede exceder los {MaxLength}c caracteres de longitud.");
		}
	}
}