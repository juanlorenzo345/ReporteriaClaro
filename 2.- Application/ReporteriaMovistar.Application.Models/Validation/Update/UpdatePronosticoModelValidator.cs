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
//     Nombre: UpdatePronosticoModelValidator.cs
//     Fecha creación: 2021/11/02 at 08:54 AM
//     Fecha modificación: 2021/11/02 at 08:54 AM
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
	public class UpdatePronosticoModelValidator : AbstractValidatorMudBlazorBase<UpdatePronosticoModel>
	{
		public UpdatePronosticoModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdatePronosticoModel, int>());
			RuleFor(p => p.Periodo).NotEmpty().WithMessage("El período está vacío.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("El período no puede ser menor a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("El período no puede ser mayor a {MaxDate}.");
			RuleFor(p => p.Tecnologia.Id).NotEmpty().WithMessage("La tecnología está vacía.");
			RuleFor(p => p.Estimacion).NotEmpty().WithMessage("La estimación está vacía.").GreaterThanOrEqualTo(0.0000M).WithMessage("La estimación debe ser mayor o igual a {ComparisonValue}.").LessThanOrEqualTo(10000000.0000M).WithMessage("La estimación debe ser menor o igual a {ComparisonValue}.");
		}
	}
}