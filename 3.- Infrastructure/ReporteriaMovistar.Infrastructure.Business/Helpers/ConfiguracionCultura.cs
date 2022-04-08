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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Infrastructure.Business
// Info archivo:
//     Nombre: ConfiguracionCultura.cs
//     Fecha creación: 2021/10/25 at 08:50 AM
//     Fecha modificación: 2021/10/25 at 08:51 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Globalization;

namespace ReporteriaMovistar.Infrastructure.Business.Helpers
{
	public static class ConfiguracionCultura
	{
		#region Fields

		private const string CodigoCultura = "es-CL";

		#endregion

		#region Constructors

		static ConfiguracionCultura()
		{
			Cultura = new CultureInfo(CodigoCultura);
		}

		#endregion

		#region Properties and Indexers

		public static CultureInfo Cultura
		{
			get;
		}

		public static string FormatoFechaCorta
		{
			get => "dd-MM-yyyy";
		}

		public static string FormatoFechaHora12Horas
		{
			get => string.Join(" ", FormatoFechaCorta, FormatoHora12Horas);
		}

		public static string FormatoFechaHora24Horas
		{
			get => string.Join(" ", FormatoFechaCorta, FormatoHora24Horas);
		}

		public static string FormatoFechaLarga
		{
			get => "dddd, dd MMMM yyyy";
		}

		public static string FormatoHora12Horas
		{
			get => "hh:mm:ss tt";
		}

		public static string FormatoHora24Horas
		{
			get => "HH:mm:ss";
		}

		public static string FormatoMesAno
		{
			get => "MMMM yyyy";
		}

		#endregion
	}
}