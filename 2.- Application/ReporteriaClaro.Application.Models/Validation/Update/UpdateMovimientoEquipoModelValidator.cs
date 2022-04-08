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
//     Nombre: UpdateMovimientoEquipoModelValidator.cs
//     Fecha creación: 2021/11/02 at 08:53 AM
//     Fecha modificación: 2021/11/02 at 08:53 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Validation.Custom;

namespace ReporteriaClaro.Application.Models.Validation.Update
{
	public class UpdateMovimientoEquipoModelValidator : AbstractValidatorMudBlazorBase<UpdateMovimientoEquipoModel>
	{
		public UpdateMovimientoEquipoModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdateMovimientoEquipoModel, int>());
			RuleFor(m => m.Fecha).NotEmpty().WithMessage("La fecha está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha debe ser mayor o igual a {MinDate}.").MaximumDate(new DateTime(2099, 31, 12)).WithMessage("La fecha debe ser menor o igual a {MaxDate}.");
			RuleFor(m => m.EtapaOrigen.Id).NotEmpty().WithMessage("La etapa de origen está vacía.");
			RuleFor(m => m.EtapaDestino).NotEmpty().WithMessage("La etapa de destino esta vacía.");
			When(m => !string.IsNullOrWhiteSpace(m.Observacion), () =>
			{
				RuleFor(m => m.Observacion).MaximumLength(200).WithMessage("La observación no debe exceder los {MaxLength} caracteres de longitud.");
			});
		}
	}
}