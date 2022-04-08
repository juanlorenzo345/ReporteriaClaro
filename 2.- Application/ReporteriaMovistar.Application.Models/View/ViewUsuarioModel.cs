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
//     Nombre: ViewUsuarioModel.cs
//     Fecha creación: 2021/11/02 at 09:09 AM
//     Fecha modificación: 2021/11/02 at 09:09 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaMovistar.Application.Models.View
{
	public class ViewUsuarioModel : ViewModelBase<string>
	{
		public string Usuario
		{
			get;
			set;
		}

		public string Nombre
		{
			get;
			set;
		}

		public bool Activo
		{
			get;
			set;
		}

		public string RazonDesactivacion
		{
			get;
			set;
		}
	}
}