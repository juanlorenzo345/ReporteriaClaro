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
//     Nombre: NewEncabezadoDespachoModelValidator.cs
//     Fecha creación: 2021/11/12 at 10:53 AM
//     Fecha modificación: 2021/11/12 at 10:53 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Validation.Custom;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
	public class NewEncabezadoDespachoModelValidator : AbstractValidatorMudBlazorBase<NewEncabezadoDespachoModel>
	{
		public NewEncabezadoDespachoModelValidator()
		{
			Include(new NewModelValidatorBase<NewEncabezadoDespachoModel>());
			RuleFor(e => e.Fecha).NotEmpty().WithMessage("La fecha está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha no puede ser menor a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha no puede ser mayor a {MaxDate}.");
			RuleFor(e => e.Guia).NotEmpty().WithMessage("La guía está vacía.").MaximumLength(50).WithMessage("La guía no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(e => e.Estado.Id).NotEmpty().WithMessage("El estado está vacío.").GreaterThan(0).WithMessage("El estado está vacío.");
		}
	}
}