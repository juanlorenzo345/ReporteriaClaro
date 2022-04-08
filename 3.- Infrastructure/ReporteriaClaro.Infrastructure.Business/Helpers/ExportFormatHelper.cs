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
//     Nombre: ExportFormatHelper.cs
//     Fecha creación: 2021/11/18 at 01:13 PM
//     Fecha modificación: 2021/11/18 at 01:13 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Infrastructure.Business.Helpers
{
	internal static class ExportFormatHelper
	{
		#region Fields

		private const string BaseName = "Ejemplo carga";

		private const string DateFormat = "dd.MM.yyyy HH.mm.ss";

		#endregion

		#region Methods

		internal static string GetBulkLoadFileName(string name, DateTime creationDate)
		{
			return $"{BaseName} {name} ({creationDate.ToString(DateFormat)})";
		}

		#endregion
	}
}