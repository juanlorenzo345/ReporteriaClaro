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
//     Nombre: UpdateUsuarioApiModelValidator.cs
//     Fecha creación: 2021/11/29 at 12:32 PM
//     Fecha modificación: 2021/11/29 at 12:32 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Update;

namespace ReporteriaClaro.Application.Models.Validation.Update
{
	public class UpdateUsuarioApiModelValidator : AbstractValidatorMudBlazorBase<UpdateUsuarioApiModel>
	{
		public UpdateUsuarioApiModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdateUsuarioApiModel, int>());
			RuleFor(u => u.Comentario).NotEmpty().WithMessage("El comentario está vacío.").MaximumLength(200).WithMessage("El comentario no puede exceder los {MaxLength} caracteres de longitud.");
		}
	}
}