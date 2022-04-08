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
//     Nombre: NewModelValidatorBase.cs
//     Fecha creación: 2021/11/03 at 12:42 PM
//     Fecha modificación: 2021/11/03 at 12:42 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Validation.Custom;

namespace ReporteriaMovistar.Application.Models.Validation.Insert
{
	public class NewModelValidatorBase<T> : AbstractValidatorMudBlazorBase<T> where T : NewModelBase
	{
		public NewModelValidatorBase()
		{
			RuleFor(n => n.FechaCreacionRegistro).NotEmpty().WithMessage("La fecha de creación está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha de creación no puede ser menor a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha de creación no puede ser mayor a {MaxDate}.");
			RuleFor(n => n.UsuarioCreacionRegistro).NotEmpty().WithMessage("El usuario de creación está vacío.").MaximumLength(256).WithMessage("El usuario de creación no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(n => n.Activo).Equal(true).WithMessage("El estado activo debe ser 1.");
		}
	}
}