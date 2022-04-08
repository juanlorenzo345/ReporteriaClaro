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
//     Nombre: DateTimeValidator.cs
//     Fecha creación: 2021/10/28 at 09:22 AM
//     Fecha modificación: 2021/10/28 at 09:22 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using FluentValidation;

namespace ReporteriaMovistar.Application.Models.Validation.Custom
{
	public static class DateTimeValidatorExtensions
	{
		public static IRuleBuilderOptions<T, DateTime> MinimumDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder, DateTime minimumDate)
		{
			return ruleBuilder.SetValidator(new MinimumDateValidator<T>(minimumDate));
		}

		public static IRuleBuilderOptions<T, DateTime?> MinimumDate<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, DateTime minimumDate)
		{
			return ruleBuilder.SetValidator(new MinimumNullableDateValidator<T>(minimumDate));
		}

		public static IRuleBuilderOptions<T, DateTime> MaximumDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder, DateTime maximumDate)
		{
			return ruleBuilder.SetValidator(new MaximumDateValidator<T>(maximumDate));
		}

		public static IRuleBuilderOptions<T, DateTime?> MaximumDate<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, DateTime maximumDate)
		{
			return ruleBuilder.SetValidator(new MaximumNullableDateValidator<T>(maximumDate));
		}

		/*public static IRuleBuilder<T, DateTime> MinimumDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder, DateTime minimumDate)
		{
			return ruleBuilder.Must((rootObject, date, context) =>
			{
				context.MessageFormatter.AppendArgument("MinDate", minimumDate);
				return date.Date >= minimumDate.Date;
			});
		}

		public static IRuleBuilder<T, DateTime> MaximumDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder, DateTime maximumDate)
		{
			return ruleBuilder.Must((rootObject, date, context) =>
			{
				context.MessageFormatter.AppendArgument("MaxDate", maximumDate);
				return date.Date <= maximumDate.Date;
			});
		}*/
	}
}