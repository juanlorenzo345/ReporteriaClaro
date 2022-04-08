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
//     Nombre: UpdateEstadoEtapaModelValidator.cs
//     Fecha creación: 2021/11/08 at 05:26 PM
//     Fecha modificación: 2021/11/08 at 05:26 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Update;

namespace ReporteriaMovistar.Application.Models.Validation.Update
{
	public class UpdateEstadoEtapaModelValidator : AbstractValidatorMudBlazorBase<UpdateEstadoEtapaModel>
	{
		public UpdateEstadoEtapaModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdateEstadoEtapaModel, int>());
			RuleFor(e => e.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(50).WithMessage("El nombre no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(e => e.Posicion).NotEmpty().WithMessage("La posición esta vacía.").GreaterThan(0).WithMessage("La posición debe ser mayor a {ComparisonValue}.");
		}
	}
}