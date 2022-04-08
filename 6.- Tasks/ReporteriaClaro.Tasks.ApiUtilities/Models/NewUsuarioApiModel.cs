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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Tasks.ApiUtilities
// Info archivo:
//     Nombre: NewUsuarioApiModel.cs
//     Fecha creación: 2021/11/26 at 01:18 PM
//     Fecha modificación: 2021/11/26 at 01:18 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Tasks.ApiUtilities.Models
{
	public class NewUsuarioApiModel
	{
		public string HashLlave
		{
			get;
			set;
		}

		public string Comentarios
		{
			get;
			set;
		}

		public DateTime FechaCreacion
		{
			get;
			set;
		}

		public string UsuarioCreacion
		{
			get;
			set;
		}
	}
}