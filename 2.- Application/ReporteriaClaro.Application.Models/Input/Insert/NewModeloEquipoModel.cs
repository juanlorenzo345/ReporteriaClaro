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
//     Nombre: NewModeloEquipoModel.cs
//     Fecha creación: 2021/10/27 at 05:21 PM
//     Fecha modificación: 2021/10/27 at 05:21 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaClaro.Application.Models.Input.Choice;

namespace ReporteriaClaro.Application.Models.Input.Insert
{
	public class NewModeloEquipoModel : NewModelBase
	{
		public string Nombre
		{
			get;
			set;
		}

		public ChoiceMarcaEquipoModel Marca
		{
			get;
			set;
		}// = new ChoiceMarcaEquipoModel() { Id = -1, Nombre = string.Empty };

		public ChoiceTecnologiaEquipoModel Tecnologia
		{
			get;
			set;
		}// = new ChoiceTecnologiaEquipoModel() { Id = -1, Nombre = string.Empty };
	}
}