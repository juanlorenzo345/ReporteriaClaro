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
//     Nombre: EmpaqueCsvModel.cs
//     Fecha creación: 2021/12/07 at 09:08 AM
//     Fecha modificación: 2021/12/07 at 09:08 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using CsvHelper.Configuration.Attributes;

namespace ReporteriaClaro.Infrastructure.Business.Csv.Models
{
	public class MovimientoEquipoAEtapaPosteriorCsvModel
	{
		[Index(0)]
		public DateTime Fecha
		{
			get;
			set;
		}

		[Index(1)]
		public string Esn
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
		public string Observacion
		{
			get;
			set;
		}
	}
}