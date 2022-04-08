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
//     Nombre: Result.cs
//     Fecha creación: 2021/10/25 at 08:36 AM
//     Fecha modificación: 2021/10/25 at 08:37 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;

namespace ReporteriaMovistar.Application.Models.Output
{
	public class Result
	{
		#region Constructors

		public Result()
		{
			Type = ResultType.Succeeded;
			Errors = new List<string>();
		}

		public Result(ResultType type, IEnumerable<string> errors)
		{
			Type = type;
			Errors = errors;
		}

		public Result(ResultType type, string error)
		{
			Type = type;
			Errors = new List<string> { error };
		}

		#endregion

		#region Properties and Indexers

		public IEnumerable<string> Errors
		{
			get;
			set;
		}

		public ResultType Type
		{
			get;
			set;
		}

		#endregion
	}
}