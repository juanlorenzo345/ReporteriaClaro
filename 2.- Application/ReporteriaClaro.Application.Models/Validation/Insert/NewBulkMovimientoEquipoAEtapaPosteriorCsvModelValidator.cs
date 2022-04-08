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
//     Nombre: NewBulkMovimientoEmpaqueADespachoCsvModelValidator.cs
//     Fecha creación: 2021/12/07 at 12:03 PM
//     Fecha modificación: 2021/12/07 at 12:03 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
	public class NewBulkMovimientoEquipoAEtapaPosteriorCsvModelValidator : AbstractValidatorMudBlazorBase<NewBulkMovimientoEquipoAEtapaPosteriorCsvModel>
	{
		public NewBulkMovimientoEquipoAEtapaPosteriorCsvModelValidator()
		{
			RuleFor(m => m.Movimientos).Must(m => !HayDuplicado(m)).WithMessage("Hay duplicados de ESN.");
			RuleForEach(m => m.Movimientos).SetValidator(new NewMovimientoEquipoAEtapaPosteriorCsvModelValidator());
		}

		private static bool HayDuplicado(List<NewMovimientoEquipoAEtapaPosteriorCsvModel> modelo)
		{
			return modelo.GroupBy(m => m.Esn).Any(g => g.Count() > 1);
		}
	}
}