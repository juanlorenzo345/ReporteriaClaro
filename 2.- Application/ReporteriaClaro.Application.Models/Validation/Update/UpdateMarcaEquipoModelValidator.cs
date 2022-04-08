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
//     Nombre: UpdateMarcaEquipoModelValidator.cs
//     Fecha creación: 2021/11/02 at 08:51 AM
//     Fecha modificación: 2021/11/02 at 08:51 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Update;

namespace ReporteriaClaro.Application.Models.Validation.Update
{
	public class UpdateMarcaEquipoModelValidator : AbstractValidatorMudBlazorBase<UpdateMarcaEquipoModel>
	{
		public UpdateMarcaEquipoModelValidator()
		{
			Include(new UpdateModelValidatorBase<UpdateMarcaEquipoModel, int>());
			RuleFor(m => m.Nombre).NotEmpty().WithMessage("El nombre está vacío.").MaximumLength(50).WithMessage("El nombre no puede exceder los {MaxLength}c caracteres de longitud.");
		}
	}
}