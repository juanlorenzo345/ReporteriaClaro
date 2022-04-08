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
//     Nombre: ExcelTableAttribute.cs
//     Fecha creación: 2021/10/25 at 08:35 AM
//     Fecha modificación: 2021/10/25 at 08:36 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Reflection;

namespace ReporteriaMovistar.Application.Models.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class ExcelTableAttribute : Attribute
	{
		#region Fields

		private string tableName;

		#endregion

		#region Constructors

		public ExcelTableAttribute(string tableName)
		{
			this.tableName = tableName;
		}

		#endregion

		#region Properties and Indexers

		public string TableName
		{
			get
			{
				return this.tableName;
			}
		}

		#endregion

		#region Methods

		public static string GetTableName(Type type)
		{
			ExcelTableAttribute attribute = type.GetCustomAttribute<ExcelTableAttribute>(false);
			return attribute?.TableName;
		}

		#endregion
	}
}