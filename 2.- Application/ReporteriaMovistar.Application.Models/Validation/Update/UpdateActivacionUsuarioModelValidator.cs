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
//     Nombre: UpdateActivacionUsuarioModelValidator.cs
//     Fecha creación: 2021/11/05 at 11:33 AM
//     Fecha modificación: 2021/11/05 at 11:33 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Application.Models.Validation.Custom;

namespace ReporteriaMovistar.Application.Models.Validation.Update
{
	public class UpdateActivacionUsuarioModelValidator : AbstractValidatorMudBlazorBase<UpdateActivacionUsuarioModel>
	{
		public UpdateActivacionUsuarioModelValidator()
		{
			RuleFor(a => a.Id).NotEmpty().WithMessage("El ID está vacío.").MaximumLength(450).WithMessage("El ID no puede exceder los {MaxLength} caracteres de longitud.");
			When(a => !a.Activo, () =>
			{
				RuleFor(a => a.Razon).NotEmpty().WithMessage("La razón está vacía.").MaximumLength(450).WithMessage("La razón ID no puede exceder los {MaxLength} caracteres de longitud.");
				RuleFor(a => a.FechaDesactivacion).NotEmpty().WithMessage("La fecha de desactivación está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha de desactivación no puede ser menor a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha de desactivación no puede ser mayor a {MaxDate}.");
				RuleFor(a => a.UsuarioDesactivacion).NotEmpty().WithMessage("El usuario de desactivación está vacío.").MaximumLength(255).WithMessage("El usuario de desactivación no puede exceder los {MaxLength} caracteres de longitud.");
			});
			When(a => a.Activo, () =>
			{
				RuleFor(a => a.Razon).Empty().WithMessage("La razón debe estar vacía.");
				RuleFor(a => a.FechaDesactivacion).Empty().WithMessage("La fecha de desactivación debe estar vacía.");
				RuleFor(a => a.UsuarioDesactivacion).Empty().WithMessage("El usuario de desactivación debe estar vacío.");
			});
		}
	}
}