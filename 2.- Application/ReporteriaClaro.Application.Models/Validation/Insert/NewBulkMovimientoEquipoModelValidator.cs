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
//     Nombre: NewDetalleMovimientoEquipoModelValidator.cs
//     Fecha creación: 2021/11/18 at 08:41 AM
//     Fecha modificación: 2021/11/18 at 08:41 AM
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
	public class NewBulkMovimientoEquipoModelValidator : AbstractValidatorMudBlazorBase<NewBulkMovimientoEquipoModel>
	{
		public NewBulkMovimientoEquipoModelValidator()
		{
			RuleFor(m => m.Movimientos).NotEmpty().WithMessage("No se han agregado ESN.").Must(m => !HayDuplicado(m)).WithMessage("Hay duplicados de ESN.");
			RuleForEach(m => m.Movimientos).SetValidator(new NewMovimientoEquipoModelValidator());
		}

		private static bool HayDuplicado(List<NewMovimientoEquipoModel> modelo)
		{
			return modelo.GroupBy(m => m.Equipo.Id).Any(m => m.Count() > 1);
		}
	}
}