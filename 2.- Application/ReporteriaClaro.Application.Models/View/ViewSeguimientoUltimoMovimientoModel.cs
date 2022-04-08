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
//     Nombre: ViewSeguimientoUltimoMovimientoModel.cs
//     Fecha creación: 2021/11/23 at 08:42 AM
//     Fecha modificación: 2021/11/23 at 08:42 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Application.Models.View
{
	public class ViewSeguimientoUltimoMovimientoModel
	{
		public DateTime? Fecha
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