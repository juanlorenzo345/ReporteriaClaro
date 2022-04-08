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
//     Nombre: NewDetalleDespachoModelValidator.cs
//     Fecha creación: 2021/11/12 at 09:38 AM
//     Fecha modificación: 2021/11/12 at 09:39 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using FluentValidation;
using ReporteriaClaro.Application.Models.Input.Insert;

namespace ReporteriaClaro.Application.Models.Validation.Insert
{
	public class NewDetalleDespachoModelValidator : AbstractValidatorMudBlazorBase<NewDetalleDespachoModel>
	{
		public NewDetalleDespachoModelValidator()
		{
			Include(new NewModelValidatorBase<NewDetalleDespachoModel>());
			RuleFor(d => d.IdEncabezado).NotEmpty().WithMessage("El ID de detalle está vacío.");
			RuleFor(d => d.Equipo.Id).NotEmpty().WithMessage("El equipo está vacío.").GreaterThan(0).WithMessage("El equipo está vacío.");
			RuleFor(d => d.Caja).NotEmpty().WithMessage("La caja está vacía.").GreaterThan(0).WithMessage("La caja debe ser mayor a {ComparisonValue}.").LessThanOrEqualTo(24).WithMessage("La caja debe ser menor o igual a {ComparisonValue}.");
			RuleFor(d => d.Pallet).NotEmpty().WithMessage("El pallet está vacío.").GreaterThan(0).WithMessage("El pallet debe ser mayor a {ComparisonValue}.").LessThanOrEqualTo(100).WithMessage("El pallet debe ser menor o igual a {ComparisonValue}.");
			RuleFor(d => d.Derivada).NotEmpty().WithMessage("La derivada está vacía.").MaximumLength(50).WithMessage("La derivada no puede exceder los {MaxLength} caracteres de longitud.");
			RuleFor(d => d.EstadoFuentePoder.Id).NotEmpty().WithMessage("El estado de la fuente de poder está vacío.").GreaterThan(0).WithMessage("El estado de la fuente de poder está vacío.");
			RuleFor(d => d.EstadoUtp.Id).NotEmpty().WithMessage("El estado de la UTP está vacío.").GreaterThan(0).WithMessage("El estado de la UTP está vacío.");
			RuleFor(d => d.EstadoControlRemoto.Id).NotEmpty().WithMessage("El estado del control remoto está vacío.").GreaterThan(0).WithMessage("El estado del control remoto está vacío.");
			RuleFor(d => d.EstadoHdmi.Id).NotEmpty().WithMessage("El estado del HDMI está vacío.").GreaterThan(0).WithMessage("El estado del HDMI está vacío.");
			RuleFor(d => d.EstadoRca.Id).NotEmpty().WithMessage("El estado del RCA está vacío.").GreaterThan(0).WithMessage("El estado del RCA está vacío.");
		}
	}
}