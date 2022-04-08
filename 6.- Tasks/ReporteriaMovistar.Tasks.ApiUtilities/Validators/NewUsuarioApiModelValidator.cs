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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Tasks.ApiUtilities
// Info archivo:
//     Nombre: NewUsuarioApiModelValidator.cs
//     Fecha creación: 2021/11/26 at 03:53 PM
//     Fecha modificación: 2021/11/26 at 03:53 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Tasks.ApiUtilities.Models;

namespace ReporteriaMovistar.Tasks.ApiUtilities.Validators
{
	public class NewUsuarioApiModelValidator : AbstractValidator<NewUsuarioApiModel>
	{
		public NewUsuarioApiModelValidator()
		{
			RuleFor(v => v.HashLlave).NotEmpty().WithMessage("La llave está vacía.");
			When(v => !string.IsNullOrWhiteSpace(v.Comentarios), () =>
			{
				RuleFor(v => v.Comentarios).MaximumLength(200).WithMessage("El comentario no puede exceder los {MaximumLength} caracteres de longitud.");
			});
			RuleFor(v => v.UsuarioCreacion).NotEmpty().WithMessage("El usuario de creación está vacío.");
		}
	}
}