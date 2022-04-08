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
//     Nombre: NewRolUsuarioModelValidator.cs
//     Fecha creación: 2021/10/27 at 01:35 PM
//     Fecha modificación: 2021/10/27 at 01:35 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaMovistar.Application.Models.Input.Insert;

namespace ReporteriaMovistar.Application.Models.Validation.Insert
{
	public class NewRolUsuarioModelValidator : AbstractValidatorMudBlazorBase<NewRolUsuarioModel>
	{
		public NewRolUsuarioModelValidator()
		{
			Include(new NewModelValidatorBase<NewRolUsuarioModel>());
			RuleFor(r => r.IdUsuario).NotEmpty().WithMessage("El ID de usuario está vacío.");
			RuleFor(r => r.Rol.Id).NotEmpty().WithMessage("El rol está vacío.");
		}
	}
}