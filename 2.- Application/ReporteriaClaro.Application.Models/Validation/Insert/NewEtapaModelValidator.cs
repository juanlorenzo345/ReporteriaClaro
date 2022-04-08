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
//     Nombre: NewEtapaModelValidator.cs
//     Fecha creación: 2021/10/28 at 08:52 AM
//     Fecha modificación: 2021/10/28 at 08:52 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
	public class NewEtapaModelValidator : AbstractValidatorMudBlazorBase<NewEtapaModel>
	{
		public NewEtapaModelValidator()
		{
			Include(new NewModelValidatorBase<NewEtapaModel>());
			RuleFor(e => e.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(50).WithMessage("El nombre no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(e => e.Posicion).NotEmpty().WithMessage("La posición no puede ser vacía.").GreaterThan(0).WithMessage("La posición tiene que ser mayor a {ComparisonValue}.");
			RuleFor(e => e.Zona.Id).NotEmpty().WithMessage("La zona esta vacía.").GreaterThan(0).WithMessage("La zona está vacía.");
		}
	}
}