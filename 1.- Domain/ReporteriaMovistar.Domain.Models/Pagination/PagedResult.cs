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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Domain.Models
// Info archivo:
//     Nombre: PagedResult.cs
//     Fecha creación: 2021/10/25 at 08:48 AM
//     Fecha modificación: 2021/10/25 at 08:49 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;

namespace ReporteriaMovistar.Domain.Models.Pagination
{
	public class PagedResult<T> : PagedResultBase where T : class
	{
		#region Constructors

		public PagedResult()
		{
			Results = new List<T>();
		}

		#endregion

		#region Properties and Indexers

		public IList<T> Results { get; set; }

		#endregion
	}
}