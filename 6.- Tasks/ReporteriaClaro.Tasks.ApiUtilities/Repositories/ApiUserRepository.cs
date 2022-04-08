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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Tasks.ApiUtilities
// Info archivo:
//     Nombre: ApiUserRepository.cs
//     Fecha creación: 2021/11/26 at 01:20 PM
//     Fecha modificación: 2021/11/26 at 01:20 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReporteriaClaro.Tasks.ApiUtilities.Entities;

namespace ReporteriaClaro.Tasks.ApiUtilities.Repositories
{
	internal class ApiUserRepository
	{
		private readonly string connectionString;

		internal ApiUserRepository()
		{
			this.connectionString = Program.Configuration.GetConnectionString("DbReporteriaClaro");
		}

		internal async Task<bool> CrearUsuarioAsync(ApiUserEntity entity)
		{
			using (SqlConnection conexion = new SqlConnection(this.connectionString))
			{
				await conexion.OpenAsync();

				using (SqlCommand comando = new SqlCommand("SP_CrearUsuarioApi", conexion))
				{
					string nombreParametroKeyHash = "@keyHash";
					string nombreParametroComments = "@comments";
					string nombreParametroCreatedAt = "@createdAt";
					string nombreParametroCreatedBy = "@createdBy";
					comando.CommandType = CommandType.StoredProcedure;
					comando.Parameters.Add(new SqlParameter()
					{
						ParameterName = nombreParametroKeyHash, SqlDbType = SqlDbType.VarChar,
						Direction = ParameterDirection.Input, Value = entity.KeyHash
					});
					comando.Parameters.Add(new SqlParameter()
					{
						ParameterName = nombreParametroComments, SqlDbType = SqlDbType.VarChar,
						Direction = ParameterDirection.Input, Value = entity.Comments
					});
					comando.Parameters.Add(new SqlParameter()
					{
						ParameterName = nombreParametroCreatedAt, SqlDbType = SqlDbType.DateTime,
						Direction = ParameterDirection.Input, Value = entity.CreatedAt
					});
					comando.Parameters.Add(new SqlParameter()
					{
						ParameterName = nombreParametroCreatedBy, SqlDbType = SqlDbType.VarChar,
						Direction = ParameterDirection.Input, Value = entity.CreatedBy
					});

					return await comando.ExecuteNonQueryAsync() > 0;
				}
			}
		}
	}
}