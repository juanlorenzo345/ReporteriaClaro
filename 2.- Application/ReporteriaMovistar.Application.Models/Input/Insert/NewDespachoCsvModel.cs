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
//     Nombre: NewDespachoModel.cs
//     Fecha creación: 2021/11/23 at 03:34 PM
//     Fecha modificación: 2021/11/23 at 03:34 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaMovistar.Application.Models.Input.Insert
{
	public class NewDespachoCsvModel
	{
		public string Esn
		{
			get;
			set;
		}

		public DateTime Fecha
		{
			get;
			set;
		}

		public string Operario
		{
			get;
			set;
		}

		public int Caja
		{
			get;
			set;
		}

		public int Pallet
		{
			get;
			set;
		}

		public bool Pintura
		{
			get;
			set;
		}

		public bool ProcesoFinalizado
		{
			get;
			set;
		}

		public string Derivada
		{
			get;
			set;
		}

		public string Guia
		{
			get;
			set;
		}

		public string EstadoDespacho
		{
			get;
			set;
		}

		public string FuentePoder
		{
			get;
			set;
		}

		public string Utp
		{
			get;
			set;
		}

		public string ControlRemoto
		{
			get;
			set;
		}

		public string Hdmi
		{
			get;
			set;
		}

		public string Rca
		{
			get;
			set;
		}
	}
}