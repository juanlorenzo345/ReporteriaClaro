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
//     Nombre: ViewSeguimientoDespachoModel.cs
//     Fecha creación: 2021/11/23 at 08:38 AM
//     Fecha modificación: 2021/11/23 at 08:38 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Application.Models.View
{
	public class ViewSeguimientoDespachoModel
	{
		public DateTime? Fecha
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

		public int? Caja
		{
			get;
			set;
		}

		public int? Pallet
		{
			get;
			set;
		}

		public string Derivada
		{
			get;
			set;
		}

		public string EstadoUtp
		{
			get;
			set;
		}

		public string EstadoFuentePoder
		{
			get;
			set;
		}

		public string EstadoControlRemoto
		{
			get;
			set;
		}

		public string EstadoHdmi
		{
			get;
			set;
		}

		public string EstadoRca
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
	}
}