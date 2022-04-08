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
//     Nombre: ChoiceEquipoModel.cs
//     Fecha creación: 2021/11/09 at 10:23 AM
//     Fecha modificación: 2021/11/09 at 10:23 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Application.Models.Input.Choice
{
	public class ChoiceEquipoModel
	{
		public int Id
		{
			get;
			set;
		}

		public string Esn
		{
			get;
			set;
		}

		public string Marca
		{
			get;
			set;
		}

		public string Modelo
		{
			get;
			set;
		}

		public string Color
		{
			get;
			set;
		}

		public int? IdTecnologia
		{
			get;
			set;
		}
	}
}