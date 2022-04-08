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
//     Nombre: NewBulkMovimientoEquipoCsvModel.cs
//     Fecha creación: 2021/12/07 at 11:51 AM
//     Fecha modificación: 2021/12/07 at 11:51 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;

namespace ReporteriaMovistar.Application.Models.Input.Insert
{
	public class NewBulkMovimientoEquipoAEtapaPosteriorCsvModel
	{
		public List<NewMovimientoEquipoAEtapaPosteriorCsvModel> Movimientos
		{
			get;
			set;
		} = new List<NewMovimientoEquipoAEtapaPosteriorCsvModel>();
	}
}