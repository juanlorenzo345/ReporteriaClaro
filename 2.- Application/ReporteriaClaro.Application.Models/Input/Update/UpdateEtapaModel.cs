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
//     Nombre: UpdateEtapaModel.cs
//     Fecha creación: 2021/11/02 at 08:34 AM
//     Fecha modificación: 2021/11/02 at 08:34 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaClaro.Application.Models.Input.Choice;

namespace ReporteriaClaro.Application.Models.Input.Update
{
	public class UpdateEtapaModel : UpdateModelBase<int>
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
		}
	}
}