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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Application.Models
// Info archivo:
//     Nombre: ExcelTableColumnAttribute.cs
//     Fecha creación: 2021/10/25 at 08:35 AM
//     Fecha modificación: 2021/10/25 at 08:36 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Reflection;

namespace ReporteriaClaro.Application.Models.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ExcelTableColumnAttribute : Attribute
	{
		#region Fields

		private string columnHeader;

		private ushort columnPosition;

		#endregion

		#region Constructors

		public ExcelTableColumnAttribute(string columnHeader, ushort columnPosition)
		{
			this.columnHeader = columnHeader;
			this.columnPosition = columnPosition;
		}

		#endregion

		#region Properties and Indexers

		public string ColumnHeader
		{
			get
			{
				return this.columnHeader;
			}
		}

		public ushort ColumnPosition
		{
			get
			{
				return this.columnPosition;
			}
		}

		#endregion

		#region Methods

		public static string GetColumnHeader(Type type, string propertyName)
		{
			PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			ExcelTableColumnAttribute attribute = propertyInfo?.GetCustomAttribute<ExcelTableColumnAttribute>(false);
			return attribute?.ColumnHeader;
		}

		public static (string header, ushort position) GetColumnInfo(Type type, string propertyName)
		{
			PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			ExcelTableColumnAttribute attribute = propertyInfo?.GetCustomAttribute<ExcelTableColumnAttribute>(false);
			return (attribute?.ColumnHeader, attribute?.ColumnPosition ?? 0);
		}

		public static ushort GetColumnPosition(Type type, string propertyName)
		{
			PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			ExcelTableColumnAttribute attribute = propertyInfo?.GetCustomAttribute<ExcelTableColumnAttribute>(false);
			return attribute?.ColumnPosition ?? 0;
		}

		#endregion
	}
}