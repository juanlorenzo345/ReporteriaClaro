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
//     Nombre: NewMovimientoEquipoCsvModelValidator.cs
//     Fecha creación: 2021/12/07 at 11:55 AM
//     Fecha modificación: 2021/12/07 at 11:55 AM
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
	public class NewMovimientoEquipoAEtapaPosteriorCsvModelValidator : AbstractValidatorMudBlazorBase<NewMovimientoEquipoAEtapaPosteriorCsvModel>
	{
		public NewMovimientoEquipoAEtapaPosteriorCsvModelValidator()
		{
			RuleFor(m => m.Fecha).NotEmpty().WithMessage("La fecha está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha debe ser mayor o igual a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha debe ser menor o igual a {MaxDate}.");
			RuleFor(m => m.Esn).NotEmpty().WithMessage("El ESN está vacío.").MaximumLength(50).WithMessage("El ESN no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(m => m.Operario).NotEmpty().WithMessage("El operario está vacío.").MaximumLength(50).WithMessage("El operario no puede exceder los {MaxLength} caracteres de longitud.");
			When(m => !string.IsNullOrWhiteSpace(m.Observacion), () =>
			{
				RuleFor(m => m.Observacion).MaximumLength(200).WithMessage("La observación no debe exceder los {MaxLength} caracteres de longitud.");
			});
		}
	}
}