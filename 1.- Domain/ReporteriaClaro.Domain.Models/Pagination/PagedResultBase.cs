﻿#region Header
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
//     Nombre: PagedResultBase.cs
//     Fecha creación: 2021/10/25 at 08:48 AM
//     Fecha modificación: 2021/10/25 at 08:49 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;

namespace ReporteriaClaro.Domain.Models.Pagination
{
	public abstract class PagedResultBase
	{
		#region Properties and Indexers

		public int FirstRowOnPage
		{
			get
			{
				return (CurrentPage - 1) * PageSize + 1;
			}
		}

		public int LastRowOnPage
		{
			get
			{
				return Math.Min(CurrentPage * PageSize, RowCount);
			}
		}

		public int CurrentPage
		{
			get;
			set;
		}

		public int PageCount
		{
			get;
			set;
		}

		public int PageSize
		{
			get; 
			set;
		}

		public int RowCount 
		{ 
			get; 
			set;

		}

		#endregion
	}
}