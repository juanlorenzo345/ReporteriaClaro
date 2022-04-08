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
//     Nombre: DeleteModelValidatorBase.cs
//     Fecha creación: 2021/11/03 at 02:38 PM
//     Fecha modificación: 2021/11/03 at 02:38 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Validation.Custom;

namespace ReporteriaClaro.Application.Models.Validation.Delete
{
	public class DeleteModelValidatorBase<T, TKeyType> : AbstractValidatorMudBlazorBase<T> where T : DeleteModelBase<TKeyType>
	{
		public DeleteModelValidatorBase()
		{
			RuleFor(d => d.FechaEliminacionRegistro).NotEmpty().WithMessage("La fecha de eliminación está vacía.").MinimumDate(new DateTime(2000, 1, 1)).WithMessage("La fecha de eliminación no puede ser menor a {MinDate}.").MaximumDate(new DateTime(2099, 12, 31)).WithMessage("La fecha de eliminación no puede ser mayor a {MaxDate}.");
			RuleFor(d => d.UsuarioEliminacionRegistro).NotEmpty().WithMessage("El usuario de eliminación está vacío.").MaximumLength(256).WithMessage("El usuario de eliminación no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.Activo).Equal(false).WithMessage("El estado activo debe ser 0.");
		}
	}
}