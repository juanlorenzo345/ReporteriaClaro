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
//     Nombre: InvalidExcelStructureException.cs
//     Fecha creación: 2021/10/25 at 08:56 AM
//     Fecha modificación: 2021/10/25 at 08:57 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Infrastructure.Business.Exceptions
{
	/// <summary>
	/// La excepción que es lanzada cuando la estructura del archivo Excel es inválida.
	/// </summary>
	public class InvalidExcelStructureException : Exception
	{
		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="InvalidExcelStructureException"/> con un mensaje especificado por el sistema.
		/// </summary>
		public InvalidExcelStructureException()
		{
			
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="InvalidExcelStructureException"/> con el mensaje especificado en string.
		/// </summary>
		public InvalidExcelStructureException(string mensaje) : base(mensaje)
		{

		}

		#endregion
	}
}