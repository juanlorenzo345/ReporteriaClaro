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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Infrastructure.Business
// Info archivo:
//     Nombre: DespachoCsvModel.cs
//     Fecha creación: 2021/11/18 at 12:46 PM
//     Fecha modificación: 2021/11/18 at 12:46 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------

#endregion

using System;
using CsvHelper.Configuration.Attributes;

namespace ReporteriaClaro.Infrastructure.Business.Csv.Models
{
	public class DespachoCsvModel
	{
		[Index(0)]
		public string Esn
		{
			get;
			set;
		}

		[Index(1)]
		public DateTime Fecha
		{
			get;
			set;
		}

		[Index(2)]
		public string Operario
		{
			get;
			set;
		}

		[Index(3)]
		public int Caja
		{
			get;
			set;
		}

		[Index(4)]
		public int Pallet
		{
			get;
			set;
		}

		[Index(5)]
		public bool Pintura
		{
			get;
			set;
		}

		[Index(6)]
		public bool ProcesoFinalizado
		{
			get;
			set;
		}

		[Index(7)]
		public string Derivada
		{
			get;
			set;
		}

		[Index(8)]
		public string Guia
		{
			get;
			set;
		}

		[Index(9)]
		public string EstadoDespacho
		{
			get;
			set;
		}

		[Index(10)]
		public string FuentePoder
		{
			get;
			set;
		}

		[Index(11)]
		public string Utp
		{
			get;
			set;
		}

		[Index(12)]
		public string ControlRemoto
		{
			get;
			set;
		}

		[Index(13)]
		public string Hdmi
		{
			get;
			set;
		}

		[Index(14)]
		public string Rca
		{
			get;
			set;
		}
	}
}