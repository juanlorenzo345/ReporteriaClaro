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
//     Nombre: DeleteUsuarioApiModelValidator.cs
//     Fecha creación: 2021/11/29 at 12:35 PM
//     Fecha modificación: 2021/11/29 at 12:35 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Delete;

namespace ReporteriaMovistar.Application.Models.Validation.Delete
{
	public class DeleteUsuarioApiModelValidator : AbstractValidatorMudBlazorBase<DeleteUsuarioApiModel>
	{
		public DeleteUsuarioApiModelValidator()
		{
			Include(new DeleteModelValidatorBase<DeleteUsuarioApiModel, int>());
			RuleFor(u => u.Razon).NotEmpty().WithMessage("La razón está vacía.").MaximumLength(200).WithMessage("La razón no puede exceder los {MaxLength} caracteres de longitud.");
		}
	}
}