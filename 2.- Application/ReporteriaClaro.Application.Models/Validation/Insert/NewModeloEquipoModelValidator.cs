﻿#region Header
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
//     Nombre: NewModeloEquipoModelValidator.cs
//     Fecha creación: 2021/10/28 at 09:11 AM
//     Fecha modificación: 2021/10/28 at 09:11 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
	public class NewModeloEquipoModelValidator : AbstractValidatorMudBlazorBase<NewModeloEquipoModel>
	{
		public NewModeloEquipoModelValidator()
		{
			Include(new NewModelValidatorBase<NewModeloEquipoModel>());
			RuleFor(m => m.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(50).WithMessage("El nombre no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(m => m.Marca.Id).NotEmpty().WithMessage("La marca está vacía.").GreaterThan(0).WithMessage("La marca está vacía.");
			RuleFor(m => m.Tecnologia.Id).NotEmpty().WithMessage("La tecnología está vacía.").GreaterThan(0).WithMessage("La tecnología está vacía.");
		}
	}
}