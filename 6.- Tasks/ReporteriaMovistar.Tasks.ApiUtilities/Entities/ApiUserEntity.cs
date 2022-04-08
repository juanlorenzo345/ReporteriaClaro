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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Tasks.ApiUtilities
// Info archivo:
//     Nombre: ApiUserEntity.cs
//     Fecha creación: 2021/11/26 at 01:15 PM
//     Fecha modificación: 2021/11/26 at 01:15 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaMovistar.Tasks.ApiUtilities.Entities
{
	public class ApiUserEntity
	{
		public int Id
		{
			get;
			set;
		}

		public string KeyHash
		{
			get;
			set;
		}

		public string Comments
		{
			get;
			set;
		}

		public DateTime CreatedAt
		{
			get;
			set;
		}

		public string CreatedBy
		{
			get;
			set;
		}

		public DateTime ModifiedAt
		{
			get;
			set;
		}

		public string ModifiedBy
		{
			get;
			set;
		}

		public DateTime DeactivatedAt
		{
			get;
			set;
		}

		public string DeactivatedBy
		{
			get;
			set;
		}

		public bool Active
		{
			get;
			set;
		}
	}
}