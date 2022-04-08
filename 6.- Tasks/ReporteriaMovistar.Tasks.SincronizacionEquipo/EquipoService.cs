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
// Solución/Proyecto: ReporteriaMovistar / ReporteriaMovistar.Tasks.SincronizacionEquipo
// Info archivo:
//     Nombre: EquipoService.cs
//     Fecha creación: 2021/11/17 at 09:09 AM
//     Fecha modificación: 2021/11/17 at 09:09 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Threading.Tasks;
using Serilog;

namespace ReporteriaMovistar.Tasks.SincronizacionEquipo
{
	public class EquipoService
	{
		private EquipoRepository equipoRepository;

		public EquipoService()
		{
			this.equipoRepository = new EquipoRepository();
		}

		public async Task EjecutarSincronizacionRecepcionAsync()
		{
			Log.Information("Se inicia ejecución de merge equipos...");
			string usuario = "[SISTEMA] Tarea programada";
			(int cantidadEquiposComparados, int cantidadEquiposInsertados, int cantidadEquiposActualizados, DateTime fechaInicioRecepcion, DateTime fechaTerminoRecepcion) = await this.equipoRepository.EjecutarMergeEquipoAsync(DateTime.Now, usuario);
			Log.Information($"Se finaliza ejecución de merge equipos. Se compararon {cantidadEquiposComparados} registro(s), se insertaron {cantidadEquiposInsertados} nuevo(s) registro(s) y se actualizaron {cantidadEquiposActualizados} registro(s) entre las fechas {fechaInicioRecepcion:d} y {fechaTerminoRecepcion:d}.");
		}
	}
}