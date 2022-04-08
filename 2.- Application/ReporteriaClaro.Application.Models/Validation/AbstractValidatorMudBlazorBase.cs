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
//     Nombre: AbstractValidatorMudBlazorBase.cs
//     Fecha creación: 2021/10/25 at 08:38 AM
//     Fecha modificación: 2021/10/25 at 08:38 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace ReporteriaClaro.Application.Models.Validation
{
	public class AbstractValidatorMudBlazorBase<T> : AbstractValidator<T> where T : class
	{
		#region Properties and Indexers

		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			ValidationResult result = await ValidateAsync(ValidationContext<T>.CreateWithOptions((T)model, o => o.IncludeProperties(propertyName)));

			if (result.IsValid)
			{
				return Array.Empty<string>();
			}

			return result.Errors.Select(e => e.ErrorMessage);
		};

		#endregion
	}
}