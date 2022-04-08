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
//     Nombre: NewSecuenciaEtapaModel.cs
//     Fecha creación: 2021/12/06 at 12:18 PM
//     Fecha modificación: 2021/12/06 at 12:18 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaClaro.Application.Models.Input.Choice;

namespace ReporteriaClaro.Application.Models.Input.Insert
{
	public class NewSecuenciaEtapaModel : NewModelBase
	{
		public ChoiceEtapaModel EtapaOrigen
		{
			get;
			set;
		} = new ChoiceEtapaModel() { Id = -1, Nombre = string.Empty };

		public ChoiceEtapaModel EtapaDestino
		{
			get;
			set;
		} = new ChoiceEtapaModel() { Id = -1, Nombre = string.Empty };

		public bool EsEtapaAnterior
		{
			get;
			set;
		}
	}
}