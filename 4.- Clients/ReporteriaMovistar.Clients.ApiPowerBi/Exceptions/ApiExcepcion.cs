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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Clients.ApiPowerBi
// Info archivo:
//     Nombre: ApiExcepcion.cs
//     Fecha creación: 2021/11/26 at 10:52 AM
//     Fecha modificación: 2021/11/26 at 10:52 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Globalization;

namespace ReporteriaMovistar.Clients.ApiPowerBi.Exceptions
{
	public class ApiExcepcion : Exception
	{
		// Custom exception class for throwing application specific exceptions (e.g. for validation) 
		// that can be caught and handled within the application
		public ApiExcepcion() : base()
		{

		}

		public ApiExcepcion(string message) : base(message)
		{

		}

		public ApiExcepcion(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
		{

		}
	}
}