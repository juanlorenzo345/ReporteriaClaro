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
//     Nombre: EquipoRepository.cs
//     Fecha creación: 2021/11/17 at 09:00 AM
//     Fecha modificación: 2021/11/17 at 09:00 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ReporteriaMovistar.Tasks.SincronizacionEquipo
{
	public class EquipoRepository
	{
		private readonly string connectionString;

		internal EquipoRepository()
		{
			this.connectionString = Program.Configuration.GetConnectionString("DbReporteriaMovistar");
		}

		internal async Task<(int cantidadEquiposComparados, int cantidadEquiposInsertados, int cantidadEquiposActualizados, DateTime fechaInicioRecepcion, DateTime fechaTerminoRecepcion)> EjecutarMergeEquipoAsync(DateTime fecha, string usuario)
		{
			using (SqlConnection conexion = new SqlConnection(this.connectionString))
			{
				await conexion.OpenAsync();

				using (SqlCommand comando = new SqlCommand("SP_MergeEquipo", conexion))
				{
					string nombreParametroFechaMes = "@fechaMes";
					string nombreParametroFecha = "@fecha";
					string nombreParametroUsuario = "@usuario";
					string nombreParametroFilasEquipoComparadas = "@cantidadFilasEquipoComparadas";
					string nombreParametroFilasEquipoInsertadas = "@cantidadFilasEquipoInsertadas";
					string nombreParametroFilasEquipoActualizadas = "@cantidadFilasEquipoActualizadas";
					string nombreParametroFechaInicioRecepcion = "@fechaInicioRecepcion";
					string nombreParametroFechaTerminoRecepcion = "@fechaTerminoRecepcion";
					comando.CommandType = CommandType.StoredProcedure;
					comando.Parameters.Add(new SqlParameter() { ParameterName = nombreParametroFechaMes, SqlDbType = SqlDbType.Date, Direction = ParameterDirection.Input, Value = fecha });
					comando.Parameters.Add(new SqlParameter() { ParameterName = nombreParametroFecha, SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = fecha });
					comando.Parameters.Add(new SqlParameter() { ParameterName = nombreParametroUsuario, SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = usuario });
					comando.Parameters.Add(new SqlParameter() { ParameterName = nombreParametroFilasEquipoComparadas, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
					comando.Parameters.Add(new SqlParameter() { ParameterName = nombreParametroFilasEquipoInsertadas, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
					comando.Parameters.Add(new SqlParameter() { ParameterName = nombreParametroFilasEquipoActualizadas, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
					comando.Parameters.Add(new SqlParameter() { ParameterName = nombreParametroFechaInicioRecepcion, SqlDbType = SqlDbType.Date, Direction = ParameterDirection.Output });
					comando.Parameters.Add(new SqlParameter() { ParameterName = nombreParametroFechaTerminoRecepcion, SqlDbType = SqlDbType.Date, Direction = ParameterDirection.Output });

					await comando.ExecuteNonQueryAsync();
					return ((int)comando.Parameters[nombreParametroFilasEquipoComparadas].Value, (int)comando.Parameters[nombreParametroFilasEquipoInsertadas].Value, (int)comando.Parameters[nombreParametroFilasEquipoActualizadas].Value, (DateTime)comando.Parameters[nombreParametroFechaInicioRecepcion].Value, (DateTime)comando.Parameters[nombreParametroFechaTerminoRecepcion].Value);
				}
			}
		}
	}
}