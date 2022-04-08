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
//     Nombre: ExcelTableGenerator.cs
//     Fecha creación: 2021/10/25 at 08:55 AM
//     Fecha modificación: 2021/10/25 at 08:57 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using ReporteriaClaro.Application.Models.Attributes;

namespace ReporteriaClaro.Infrastructure.Business.Excel
{
	/// <summary>
	/// Provee métodos estáticos para generar tablas de Excel.
	/// </summary>
	internal static class ExcelTableGenerator
	{
		#region Methods

		internal static DataTable CrearTablaExcelVacia(Type tipo)
		{
			DataTable tabla = new DataTable(ExcelTableAttribute.GetTableName(tipo));
			Dictionary<ushort, (string encabezadoColumna, Type tipoColumna)> columnasTabla = ObtenerColumnasTabla(tipo);

			for (ushort posicion = 0; posicion < columnasTabla.Count; posicion++)
			{
				tabla.Columns.Add(columnasTabla[posicion].encabezadoColumna, columnasTabla[posicion].tipoColumna);
			}

			return tabla;
		}

		private static Dictionary<ushort, (string encabezadoColumna, Type tipoColumna)> ObtenerColumnasTabla(Type tipo)
		{
			PropertyInfo[] infoPropiedades = tipo.GetProperties();
			Dictionary<ushort, (string encabezadoColumna, Type tipoColumna)> columnasTabla = new Dictionary<ushort, (string encabezadoColumna, Type tipoColumna)>(infoPropiedades.Length);

			foreach (PropertyInfo infoPropiedad in infoPropiedades)
			{
				columnasTabla.Add(ExcelTableColumnAttribute.GetColumnPosition(tipo, infoPropiedad.Name), (ExcelTableColumnAttribute.GetColumnHeader(tipo, infoPropiedad.Name), (Type)infoPropiedad.GetValue(null)));
			}

			return columnasTabla;
		}

		#endregion
	}
}