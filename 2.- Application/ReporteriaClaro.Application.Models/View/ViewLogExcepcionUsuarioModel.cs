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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Application.Models
// Info archivo:
//     Nombre: ViewLogExcepcionUsuarioModel.cs
//     Fecha creación: 2021/11/05 at 09:49 AM
//     Fecha modificación: 2021/11/05 at 09:49 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Application.Models.View
{
	public class ViewLogExcepcionUsuarioModel
	{
		public int Id
		{
			get;
			set;
		}

		public int NumeroFila
		{
			get;
			set;
		}

		public string Usuario
		{
			get;
			set;
		}

		public string Mensaje
		{
			get;
			set;
		}

		public string Tipo
		{
			get;
			set;
		}

		public string Origen
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public DateTime FechaCreacionRegistro
		{
			get;
			set;
		}
	}
}