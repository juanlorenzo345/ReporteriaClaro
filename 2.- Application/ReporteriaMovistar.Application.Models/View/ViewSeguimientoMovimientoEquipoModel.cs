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
//     Nombre: VerHistorialMovimientoEquipoModel.cs
//     Fecha creación: 2021/11/17 at 10:46 AM
//     Fecha modificación: 2021/11/17 at 10:46 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaMovistar.Application.Models.View
{
	public class ViewSeguimientoMovimientoEquipoModel : ViewModelBase<int>
	{
		public DateTime Fecha
		{
			get;
			set;
		}

		public string Origen
		{
			get;
			set;
		}

		public string Destino
		{
			get;
			set;
		}

		public string Operario
		{
			get;
			set;
		}

		public string OperarioDevolucion
		{
			get;
			set;
		}

		public string Observacion
		{
			get;
			set;
		}
	}
}