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
//     Nombre: NewEtapaModel.cs
//     Fecha creación: 2021/10/27 at 05:19 PM
//     Fecha modificación: 2021/10/27 at 05:19 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaClaro.Application.Models.Input.Choice;

namespace ReporteriaClaro.Application.Models.Input.Insert
{
	public class NewEtapaModel : NewModelBase
	{
		public string Nombre
		{
			get;
			set;
		}

		public int Posicion
		{
			get;
			set;
		}

		public ChoiceZonaModel Zona
		{
			get;
			set;
		} = new ChoiceZonaModel() { Id = -1, Nombre = string.Empty };
	}
}