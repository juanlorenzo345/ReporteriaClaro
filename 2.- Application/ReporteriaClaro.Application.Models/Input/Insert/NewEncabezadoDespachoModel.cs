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
//     Nombre: NewEncabezadoDespachoModel.cs
//     Fecha creación: 2021/11/12 at 10:40 AM
//     Fecha modificación: 2021/11/12 at 10:40 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using ReporteriaClaro.Application.Models.Input.Choice;

namespace ReporteriaClaro.Application.Models.Input.Insert
{
	public class NewEncabezadoDespachoModel : NewModelBase
	{
		public DateTime? Fecha
		{
			get;
			set;
		} = DateTime.Now;

		public string Guia
		{
			get;
			set;
		}

		public ChoiceEstadoDespachoModel Estado
		{
			get;
			set;
		} = new ChoiceEstadoDespachoModel() { Id = -1, Nombre = "" };
	}
}