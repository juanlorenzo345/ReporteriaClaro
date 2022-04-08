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
//     Nombre: NewDespachoModelValidator.cs
//     Fecha creación: 2021/11/23 at 03:53 PM
//     Fecha modificación: 2021/11/23 at 03:53 PM
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
	public class NewDespachoCsvModelValidator : AbstractValidatorMudBlazorBase<NewDespachoCsvModel>
	{
		public NewDespachoCsvModelValidator()
		{
			RuleFor(d => d.Fecha).NotEmpty().WithMessage("La fecha está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha debe ser mayor o igual a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha debe ser menor o igual a {MaxDate}.");
			RuleFor(d => d.Esn).NotEmpty().WithMessage("El ESN está vacío.").MaximumLength(50).WithMessage("El ESN no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.Operario).NotEmpty().WithMessage("El operario está vacío.").MaximumLength(50).WithMessage("El operario no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.Caja).NotEmpty().WithMessage("La caja está vacía.").GreaterThan(0).WithMessage("La caja debe ser mayor a {ComparisonValue}.").LessThanOrEqualTo(24).WithMessage("La caja debe ser menor o igual a {ComparisonValue}.");
			RuleFor(d => d.Pallet).NotEmpty().WithMessage("El pallet está vacío.").GreaterThan(0).WithMessage("El pallet debe ser mayor a {ComparisonValue}.").LessThanOrEqualTo(100).WithMessage("El pallet debe ser menor o igual a {ComparisonValue}.");
			RuleFor(d => d.Derivada).NotEmpty().WithMessage("La derivada está vacía.").MaximumLength(50).WithMessage("La derivada no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.Guia).NotEmpty().WithMessage("La guía está vacía.").MaximumLength(50).WithMessage("La guía no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.EstadoDespacho).NotEmpty().WithMessage("El estado de despacho está vacío.").MaximumLength(50).WithMessage("El estado de despacho no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.FuentePoder).NotEmpty().WithMessage("El estado de la fuente de poder está vacío.").MaximumLength(50).WithMessage("El estado de la fuente de poder no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.Utp).NotEmpty().WithMessage("El estado de la UTP está vacío.").MaximumLength(50).WithMessage("El estado de la UTP no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.ControlRemoto).NotEmpty().WithMessage("El estado del control remoto está vacío.").MaximumLength(50).WithMessage("El estado del control remoto no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.Hdmi).NotEmpty().WithMessage("El estado del HDMI está vacío.").MaximumLength(50).WithMessage("El estado del HDMI no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.Rca).NotEmpty().WithMessage("El estado del RCA está vacío.").MaximumLength(50).WithMessage("El estado del RCA no puede exceder los {MaxLength} caracteres de longitud.");
		}
	}
}