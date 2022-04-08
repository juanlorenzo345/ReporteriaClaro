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
//     Nombre: UpdateColorEquipoModelValidator.cs
//     Fecha creación: 2021/11/02 at 08:45 AM
//     Fecha modificación: 2021/11/02 at 08:45 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Update;

namespace ReporteriaClaro.Application.Models.Validation.Update
{
	public class UpdateColorEquipoModelValidator : AbstractValidatorMudBlazorBase<UpdateColorEquipoModel>
	{
		public UpdateColorEquipoModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdateColorEquipoModel, int>());
			RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(30).WithMessage("El nombre no puede exceder los {MaxLength} caracteres de longitud.");
		}
	}
}