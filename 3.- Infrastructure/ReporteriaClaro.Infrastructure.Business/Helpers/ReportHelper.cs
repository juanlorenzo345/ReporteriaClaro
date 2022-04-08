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
//     Nombre: ReportHelper.cs
//     Fecha creación: 2021/10/25 at 08:50 AM
//     Fecha modificación: 2021/10/25 at 08:50 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Infrastructure.Business.Helpers
{
	internal static class ReportHelper
	{
		#region Fields

		private const string BaseName = "Informe";

		private const string DateFormat = "dd.MM.yyyy HH.mm.ss";

		#endregion

		#region Methods

		internal static string GetDetailedReportName(string name, DateTime creationDate)
		{
			return $"{BaseName} {name} ({creationDate.ToString(DateFormat)})";
		}

		internal static string GetDetailedReportName(string name, DateTime creationDate, DateTime period)
		{
			return $"{BaseName} {name} - {period.ToString(ConfiguracionCultura.FormatoMesAno)} ({creationDate.ToString(DateFormat)})";
		}

		internal static string GetDetailedReportName(string name, DateTime creationDate, DateTime initialDate, DateTime finalDate)
		{
			return $"{BaseName} {name} - {initialDate.ToString(ConfiguracionCultura.FormatoFechaCorta)} a {finalDate.ToString(ConfiguracionCultura.FormatoFechaCorta)} ({creationDate.ToString(DateFormat)})";
		}

		#endregion
	}
}