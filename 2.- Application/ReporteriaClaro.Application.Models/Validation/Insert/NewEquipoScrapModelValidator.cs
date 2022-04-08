using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Validation.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
    public class NewEquipoScrapModelValidator : AbstractValidatorMudBlazorBase<NewEquipoScrapModel>
	{
		public NewEquipoScrapModelValidator()
		{
			Include(new NewModelValidatorBase<NewEquipoScrapModel>());
			RuleFor(m => m.Fecha).NotEmpty().WithMessage("La fecha está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha debe ser mayor o igual a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha debe ser menor o igual a {MaxDate}.");
			RuleFor(m => m.EtapaOrigen.Id).NotEmpty().WithMessage("La etapa de origen está vacía.").GreaterThan(0).WithMessage("La etapa de origen está vacía.");
			When(m => !string.IsNullOrWhiteSpace(m.Detalle), () =>
			{
				RuleFor(m => m.Detalle).MaximumLength(200).WithMessage("La observación no debe exceder los {MaxLength} caracteres de longitud.");
			});
		}
	}
}
