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
//     Nombre: UpdateEncabezadoDespachoModelValidator.cs
//     Fecha creación: 2021/11/12 at 11:00 AM
//     Fecha modificación: 2021/11/12 at 11:00 AM
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
	public class UpdateEncabezadoDespachoModelValidator : AbstractValidatorMudBlazorBase<UpdateEncabezadoDespachoModel>
	{
		public UpdateEncabezadoDespachoModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdateEncabezadoDespachoModel, int>());
			RuleFor(e => e.Fecha).NotEmpty().WithMessage("La fecha está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha no puede ser menor a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha no puede ser mayor a {MaxDate}.");
			RuleFor(e => e.Guia).NotEmpty().WithMessage("La guía está vacía.").MaximumLength(50).WithMessage("La guía no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(e => e.Estado.Id).NotEmpty().WithMessage("El estado está vacío.").GreaterThan(0).WithMessage("El estado está vacío.");
		}
	}
}