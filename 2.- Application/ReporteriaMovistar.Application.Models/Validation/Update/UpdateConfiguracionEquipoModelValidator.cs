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
//     Nombre: UpdateConfiguracionEquipoModelValidator.cs
//     Fecha creación: 2021/11/08 at 03:24 PM
//     Fecha modificación: 2021/11/08 at 03:24 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Update;

namespace ReporteriaMovistar.Application.Models.Validation.Update
{
	public class UpdateConfiguracionEquipoModelValidator : AbstractValidatorMudBlazorBase<UpdateConfiguracionEquipoModel>
	{
		public UpdateConfiguracionEquipoModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdateConfiguracionEquipoModel, int>());
			RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(30).WithMessage("El nombre no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(c => c.Detalle).NotEmpty().WithMessage("El detalle está vacío.").MaximumLength(200).WithMessage("El detalle no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(c => c.Tecnologia.Id).NotEmpty().WithMessage("La tecnología está vacía.").GreaterThan(0).WithMessage("La tecnología está vacía.");
		}
	}
}