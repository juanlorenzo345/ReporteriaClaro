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
//     Nombre: UpdateConfiguracionEquipoModel.cs
//     Fecha creación: 2021/11/02 at 03:08 PM
//     Fecha modificación: 2021/11/02 at 03:08 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using ReporteriaMovistar.Application.Models.Input.Choice;

namespace ReporteriaMovistar.Application.Models.Input.Update
{
	public class UpdateConfiguracionEquipoModel : UpdateModelBase<int>
	{
		public string Nombre
		{
			get;
			set;
		}

		public string Detalle
		{
			get;
			set;
		}

		public ChoiceTecnologiaEquipoModel Tecnologia
		{
			get;
			set;
		}
	}
}