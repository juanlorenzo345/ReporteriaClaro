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
//     Nombre: Etapa.cs
//     Fecha creación: 2021/11/08 at 05:38 PM
//     Fecha modificación: 2021/11/08 at 05:38 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Application.Models.Enums
{
	public enum Etapa
	{
		Recepcion = 1,
		Diagnostico = 2,
		Limpieza = 3,
		Pintura = 4,
		QuickResponse = 5,
		Etiquetado = 6,
		ControlCalidad = 7,
		Empaque = 8,
		Despacho = 9,
		Cliente = 10,
		Scrap = 11
	}
}