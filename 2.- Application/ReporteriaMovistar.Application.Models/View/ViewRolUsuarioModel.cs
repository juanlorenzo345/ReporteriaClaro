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
//     Nombre: ViewRolUsuarioModel.cs
//     Fecha creación: 2021/11/05 at 12:43 PM
//     Fecha modificación: 2021/11/05 at 12:43 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaMovistar.Application.Models.View
{
	public class ViewRolUsuarioModel
	{
		public string Id
		{
			get;
			set;
		}

		public int NumeroFila
		{
			get;
			set;
		}

		public string Rol
		{
			get;
			set;
		}

		public DateTime? FechaCreacionRegistro
		{
			get;
			set;
		}

		public string UsuarioCreacionRegistro
		{
			get;
			set;
		}
	}
}