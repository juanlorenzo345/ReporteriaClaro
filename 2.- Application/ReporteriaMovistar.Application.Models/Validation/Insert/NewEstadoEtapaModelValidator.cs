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
//     Nombre: NewEstadoEtapaModelValidator.cs
//     Fecha creación: 2021/11/08 at 05:22 PM
//     Fecha modificación: 2021/11/08 at 05:22 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Insert;

namespace ReporteriaMovistar.Application.Models.Validation.Insert
{
	public class NewEstadoEtapaModelValidator : AbstractValidatorMudBlazorBase<NewEstadoEtapaModel>
	{
		public NewEstadoEtapaModelValidator()
		{
			Include(new NewModelValidatorBase<NewEstadoEtapaModel>());
			RuleFor(e => e.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(50).WithMessage("El nombre no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(e => e.Posicion).NotEmpty().WithMessage("La posición esta vacía.").GreaterThan(0).WithMessage("La posición debe ser mayor a {ComparisonValue}.");
		}
	}
}