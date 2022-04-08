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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Clients.BlazorServerSide
// Info archivo:
//     Nombre: Roles.cs
//     Fecha creación: 2021/10/26 at 03:51 PM
//     Fecha modificación: 2021/10/26 at 03:51 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaMovistar.Clients.BlazorServerSide.IdentityData
{
	internal static class Roles
	{
		internal const string SuperAdministrador = "Super administrador";

		internal const string Administrador = "Administrador";

		internal const string Diagnostico = "Diagnóstico";

		internal const string Limpieza = "Limpieza";

		internal const string Pintura = "Pintura";

		internal const string QuickResponse = "QR";

		internal const string Etiquetado = "Etiquetado";

		internal const string ControlCalidad = "Calidad";

		internal const string Empaque = "Empaque";

		internal const string Despacho = "Despacho";

		internal const string Recepcion = "Recepción";
	}
}