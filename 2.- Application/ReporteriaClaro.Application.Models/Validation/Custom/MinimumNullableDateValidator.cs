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
//     Nombre: MaximumNullableDateValidator.cs
//     Fecha creación: 2021/10/28 at 11:04 AM
//     Fecha modificación: 2021/10/28 at 11:04 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using FluentValidation;
using FluentValidation.Validators;

namespace ReporteriaClaro.Application.Models.Validation.Custom
{
	public class MinimumNullableDateValidator<T> : PropertyValidator<T, DateTime?>
	{
		private DateTime minimumDate;

		public MinimumNullableDateValidator(DateTime minimumDate)
		{
			this.minimumDate = minimumDate;
		}

		public override bool IsValid(ValidationContext<T> context, DateTime? value)
		{
			if (value is null || value.Value.Date < this.minimumDate.Date)
			{
				context.MessageFormatter.AppendArgument("MinDate", this.minimumDate.Date);
				return false;
			}

			return true;
		}

		public override string Name => "MinimumNullableDateValidator";

		protected override string GetDefaultMessageTemplate(string errorCode)
		{
			return "{PropertyName} must be greater or equal than {MinDate}";
		}
	}
}