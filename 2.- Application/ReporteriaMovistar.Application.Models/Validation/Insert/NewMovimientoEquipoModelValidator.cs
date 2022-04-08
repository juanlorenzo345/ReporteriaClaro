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
//     Nombre: NewMovimientoEquipoModelValidator.cs
//     Fecha creación: 2021/10/28 at 09:16 AM
//     Fecha modificación: 2021/10/28 at 09:16 AM
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
	public class NewMovimientoEquipoModelValidator : AbstractValidatorMudBlazorBase<NewMovimientoEquipoModel>
	{
		public NewMovimientoEquipoModelValidator()
		{
			Include(new NewModelValidatorBase<NewMovimientoEquipoModel>());
			RuleFor(m => m.Fecha).NotEmpty().WithMessage("La fecha está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha debe ser mayor o igual a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha debe ser menor o igual a {MaxDate}.");
			RuleFor(m => m.Hora).NotEmpty().WithMessage("La hora está vacía.");
			RuleFor(m => m.Equipo.Id).NotEmpty().WithMessage("El equipo está vacío.").GreaterThan(0).WithMessage("El equipo está vacío.");
			RuleFor(m => m.EtapaOrigen.Id).NotEmpty().WithMessage("La etapa de origen está vacía.").GreaterThan(0).WithMessage("La etapa de origen está vacía.");
			RuleFor(m => m.EtapaDestino.Id).NotEmpty().WithMessage("La etapa de destino está vacía.").GreaterThan(0).WithMessage("La etapa de destino está vacía.");
			RuleFor(m => m.Operario.Id).NotEmpty().WithMessage("El operario está vacío.").GreaterThan(0).WithMessage("El operario está vacío.");
			When(m => m.EtapaDestino.EsEtapaAnterior, () =>
			{
				RuleFor(m => m.OperarioDevolucion.Id).NotEmpty().WithMessage("El operario a devolver está vacío.").GreaterThan(0).WithMessage("El operario a devolver está vacío.");
			});
			When(m => !string.IsNullOrWhiteSpace(m.Observacion), () =>
			{
				RuleFor(m => m.Observacion).MaximumLength(200).WithMessage("La observación no debe exceder los {MaxLength} caracteres de longitud.");
			});
		}
	}
}