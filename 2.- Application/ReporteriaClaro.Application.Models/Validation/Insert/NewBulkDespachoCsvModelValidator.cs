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
//     Nombre: NewBulkDespachoModelValidator.cs
//     Fecha creación: 2021/11/23 at 04:04 PM
//     Fecha modificación: 2021/11/23 at 04:04 PM
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
	public class NewBulkDespachoCsvModelValidator : AbstractValidatorMudBlazorBase<NewBulkDespachoCsvModel>
	{
		public NewBulkDespachoCsvModelValidator()
		{
			RuleFor(d => d.Despachos).Must(m => !HayDuplicado(m)).WithMessage("Hay duplicados de ESN.");
			RuleForEach(d => d.Despachos).SetValidator(new NewDespachoCsvModelValidator());
		}

		private static bool HayDuplicado(List<NewDespachoCsvModel> modelo)
		{
			return modelo.GroupBy(d => d.Esn).Any(g => g.Count() > 1);
		}
	}
}