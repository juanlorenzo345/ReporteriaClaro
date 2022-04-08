﻿#region Header
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
//     Nombre: NewLogAccesoUsuarioModel.cs
//     Fecha creación: 2021/11/05 at 09:16 AM
//     Fecha modificación: 2021/11/05 at 09:16 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaMovistar.Application.Models.Input.Insert
{
	public class NewLogAccesoUsuarioModel
	{
		public string IdUsuario
		{
			get;
			set;
		}

		public string DireccionIp
		{
			get;
			set;
		}

		public DateTime FechaAcceso
		{
			get;
			set;
		}

		public bool LoginSatisfactorio
		{
			get;
			set;
		}

		public string Detalle
		{
			get;
			set;
		}
	}
}