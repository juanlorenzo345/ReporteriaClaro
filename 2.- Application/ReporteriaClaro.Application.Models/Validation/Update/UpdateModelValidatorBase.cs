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
//     Nombre: UpdateModelValidatorBase.cs
//     Fecha creación: 2021/11/03 at 02:54 PM
//     Fecha modificación: 2021/11/03 at 02:54 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Validation.Custom;

namespace ReporteriaClaro.Application.Models.Validation.Update
{
	public class UpdateModelValidatorBase<T, TKey> : AbstractValidatorMudBlazorBase<T> where T : UpdateModelBase<TKey>
	{
		public UpdateModelValidatorBase()
		{
			RuleFor(u => u.Id).NotEmpty().WithMessage("El ID está vacío.");
			RuleFor(u => u.FechaModificacionRegistro).NotEmpty().WithMessage("La fecha de modificación está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha de modificación no puede ser menor a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha de modificación no puede ser mayor a {MaxDate}.");
			RuleFor(u => u.UsuarioModificacionRegistro).NotEmpty().WithMessage("El usuario de modificación está vacío.").MaximumLength(256).WithMessage("El usuario de modificación no puede exceder los {MaxLength} caracteres de longitud.");
		}
	}
}