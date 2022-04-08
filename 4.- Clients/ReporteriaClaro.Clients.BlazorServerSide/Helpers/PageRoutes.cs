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
// Solución/Proyecto: TsaDotNet / TsaDotNet.Clients.BlazorWasm
// Info archivo:
//     Nombre: PageRoute.cs
//     Fecha creación: 2021/10/06 at 04:33 PM
//     Fecha modificación: 2021/10/06 at 04:33 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

namespace ReporteriaClaro.Clients.BlazorServerSide.Helpers
{
	internal static class PageRoutes
	{
		private const string Proceso = "/proceso";

		private const string Mantenimiento = "/mantenimiento";

		private const string Seguridad = "/seguridad";

		internal const string About = "/about";
		
		internal const string Login = "/account/login";

		internal const string Logout = "/account/logout";

		internal const string Usuarios = Seguridad + "/usuarios";

		internal const string Zonas = Mantenimiento + "/zonas";

		internal const string ColoresEquipo = Mantenimiento + "/colores-equipo";

		internal const string MarcasEquipo = Mantenimiento + "/marcas-equipo";

		internal const string ModelosEquipo = Mantenimiento + "/modelos-equipo";

		internal const string EstadosDespacho = Mantenimiento + "/estados-despacho";

		internal const string Pronosticos = Proceso + "/pronosticos";

		internal const string Etapas = Mantenimiento + "/etapas";

		internal const string TecnologiasEquipo = Mantenimiento + "/tecnologias";

		internal const string Operarios = Mantenimiento + "/operarios";

		internal const string LogExcepciones = Seguridad + "/log-excepciones";

		internal const string LogAccesos = Seguridad + "/log-accesos";

		internal const string ConfiguracionesEquipo = Mantenimiento + "/configuraciones-equipo";

		internal const string Recepcion = Proceso + "/recepcion";

		internal const string Limpieza = Proceso + "/limpieza";

		internal const string Pintura = Proceso + "/pintura";

		internal const string QuickResponse = Proceso + "/qr";

		internal const string Etiquetado = Proceso + "/etiquetado";

		internal const string ControlCalidad = Proceso + "/control-calidad";

		internal const string Empaque = Proceso + "/empaque";

		internal const string Despacho = Proceso + "/despacho";

		internal const string Scrap = Proceso +  "/scrap";

		internal const string EstadosEtapa = Mantenimiento + "/estados-etapa";

		internal const string Diagnostico = Proceso + "/diagnostico";

		internal const string EstadosComponente = Mantenimiento + "/estado-componente";

		internal const string Seguimiento = Proceso + "/seguimiento";

		internal const string UsuariosApi = Seguridad + "/usuarios-api";

		internal const string SecuenciasEtapa = Mantenimiento + "/secuencias-etapa";
	}
}