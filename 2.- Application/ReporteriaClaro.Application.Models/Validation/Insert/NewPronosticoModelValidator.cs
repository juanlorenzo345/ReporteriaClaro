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
//     Nombre: NewPronosticoModelValidator.cs
//     Fecha creación: 2021/10/28 at 11:55 AM
//     Fecha modificación: 2021/10/28 at 11:55 AM
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
	public class NewPronosticoModelValidator : AbstractValidatorMudBlazorBase<NewPronosticoModel>
	{
		public NewPronosticoModelValidator()
		{
			Include(new NewModelValidatorBase<NewPronosticoModel>());
			RuleFor(p => p.Periodo).NotEmpty().WithMessage("El período está vacío.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("El período no puede ser menor a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("El período no puede ser mayor a {MaxDate}.");
			RuleFor(p => p.Tecnologia.Id).NotEmpty().WithMessage("La tecnología está vacía.").GreaterThan(0).WithMessage("La tecnología está vacía.");
			RuleFor(p => p.Estimacion).NotEmpty().WithMessage("La estimación está vacía.").GreaterThanOrEqualTo(0.0000M).WithMessage("La estimación debe ser mayor o igual a {ComparisonValue}.").LessThanOrEqualTo(10000000.0000M).WithMessage("La estimación debe ser menor o igual a {ComparisonValue}.");
		}
	}
}