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
//     Nombre: NewSecuenciaEtapaModelValidator.cs
//     Fecha creación: 2021/12/06 at 03:26 PM
//     Fecha modificación: 2021/12/06 at 03:26 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
	public class NewSecuenciaEtapaModelValidator : AbstractValidatorMudBlazorBase<NewSecuenciaEtapaModel>
	{
		public NewSecuenciaEtapaModelValidator()
		{
			Include(new NewModelValidatorBase<NewSecuenciaEtapaModel>());
			RuleFor(d => d.EtapaOrigen.Id).NotEmpty().WithMessage("La etapa de origen está vacía.").GreaterThan(0).WithMessage("La etapa de origen está vacía.");
			RuleFor(d => d.EtapaDestino.Id).NotEmpty().WithMessage("La etapa de destino está vacía.").GreaterThan(0).WithMessage("La etapa de destino está vacía.");
		}
	}
}