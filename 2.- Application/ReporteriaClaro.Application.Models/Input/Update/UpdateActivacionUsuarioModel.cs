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
//     Nombre: UpdateActivacionUsuarioModel.cs
//     Fecha creación: 2021/11/05 at 10:59 AM
//     Fecha modificación: 2021/11/05 at 10:59 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Application.Models.Input.Update
{
	public class UpdateActivacionUsuarioModel
	{
		public string Id
		{
			get;
			set;
		}

		public string Razon
		{
			get;
			set;
		}

		public bool Activo
		{
			get;
			set;
		}

		public string UsuarioDesactivacion
		{
			get;
			set;
		}

		public DateTime? FechaDesactivacion
		{
			get;
			set;
		}
	}
}