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
//     Nombre: NewPronosticoModel.cs
//     Fecha creación: 2021/10/27 at 05:28 PM
//     Fecha modificación: 2021/10/27 at 05:28 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using ReporteriaMovistar.Application.Models.Input.Choice;

namespace ReporteriaMovistar.Application.Models.Input.Insert
{
	public class NewPronosticoModel : NewModelBase
	{
		public DateTime? Periodo
		{
			get;
			set;
		} = DateTime.Now;

		public ChoiceTecnologiaEquipoModel Tecnologia
		{
			get;
			set;
		} = new ChoiceTecnologiaEquipoModel() { Id = -1, Nombre = string.Empty};

		public decimal Estimacion
		{
			get;
			set;
		}
	}
}