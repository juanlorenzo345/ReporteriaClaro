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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Domain.Models
// Info archivo:
//     Nombre: SortingInfo.cs
//     Fecha creación: 2021/10/25 at 08:48 AM
//     Fecha modificación: 2021/10/25 at 08:49 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Domain.Models.Sorting
{
	public struct SortingInfo
	{
		public string ColumnName
		{
			get;
			set;
		}

		public SortingDirection Direction
		{
			get;
			set;
		}

		public SortingInfo(string columnName, SortingDirection direction)
		{
			this.ColumnName = columnName;
			this.Direction = direction;
		}
	}
}