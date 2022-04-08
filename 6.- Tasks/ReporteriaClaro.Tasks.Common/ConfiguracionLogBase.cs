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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Tasks.Common
// Info archivo:
//     Nombre: ConfiguracionLogBase.cs
//     Fecha creación: 2021/11/17 at 08:50 AM
//     Fecha modificación: 2021/11/17 at 09:25 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.IO;
using System.Linq;

namespace ReporteriaClaro.Tasks.Common
{
	public class ConfiguracionLogBase
	{
		#region Fields

		public const string PlantillaLog = "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {Message:lj}{NewLine}{Exception}";
		
		private const string Carpeta = "Logs";

		private readonly string directorio;

		#endregion

		#region Constructors

		public ConfiguracionLogBase(string nombreAplicacion)
		{
			this.directorio = ObtenerDirectorio();
			RutaArchivo = Path.Combine(this.directorio, $"Log {nombreAplicacion} .txt");
		}

		#endregion

		#region Properties and Indexers

		public string RutaArchivo
		{
			get;
		}

		#endregion

		#region Methods

		public string ObtenerRutaArchivoMasReciente()
		{
			DirectoryInfo infoDirectorio = new DirectoryInfo(this.directorio);
			return infoDirectorio.GetFiles().OrderByDescending(f => f.LastWriteTime).First().FullName;
		}

		private static string ObtenerDirectorio()
		{
			string directorioApp = AppContext.BaseDirectory;
			string directorioCarpeta = Path.Combine(directorioApp, Carpeta);

			if (!Directory.Exists(directorioCarpeta))
			{
				Directory.CreateDirectory(directorioCarpeta);
			}

			return directorioCarpeta;
		}

		#endregion
	}
}