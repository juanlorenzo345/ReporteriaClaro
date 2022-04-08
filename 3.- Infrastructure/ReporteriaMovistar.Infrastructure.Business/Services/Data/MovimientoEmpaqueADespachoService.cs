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
//     Nombre: MovimientoEmpaqueADespachoService.cs
//     Fecha creación: 2021/12/07 at 12:28 PM
//     Fecha modificación: 2021/12/07 at 12:28 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReporteriaMovistar.Application.Interfaces.Services.Data;
using ReporteriaMovistar.Application.Models.Enums;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Application.Models.Validation.Insert;
using ReporteriaMovistar.Domain.Interfaces.Repositories;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Csv;
using ReporteriaMovistar.Infrastructure.Business.Csv.Models;
using ReporteriaMovistar.Infrastructure.Business.File;
using ReporteriaMovistar.Infrastructure.Data.DataProviders;
using MissingFieldException = CsvHelper.MissingFieldException;

namespace ReporteriaMovistar.Infrastructure.Business.Services.Data
{
	public class MovimientoEmpaqueADespachoService : DatabaseServiceBase, IMovimientoEmpaqueADespachoService
	{
		private const int IdEtapaEmpaque = (int) Etapa.Empaque;

		private const int IdEtapaDespacho = (int) Etapa.Despacho;

		public MovimientoEmpaqueADespachoService(IDbContextFactory<ReporteriaMovistarDbContext> dbContextFactory) : base(dbContextFactory, "")
		{
		}

		public async Task<Result> ImportarArchivoAsync(Stream archivo, DateTime fecha, string usuario)
		{
			List<MovimientoEquipoAEtapaPosteriorCsvModel> modeloCsv = new List<MovimientoEquipoAEtapaPosteriorCsvModel>();
			try
			{
				modeloCsv = new CsvFileHandler().GetFileContent<MovimientoEquipoAEtapaPosteriorCsvModel>(archivo);
			}
			catch (MissingFieldException excepcion)
			{
				return new Result(ResultType.Invalid, $"No se encontró la columna {excepcion.Context.Reader.CurrentIndex + 1}.");
			}
			catch (TypeConverterException excepcion)
			{
				return new Result(ResultType.Invalid, $"No se pudo procesar el valor '{excepcion.Text}' como {CsvFileHandler.GetAliasType(excepcion.MemberMapData)} en '{excepcion.Context.Parser.RawRecord}' (columna {excepcion.Context.Reader.CurrentIndex + 1}, fila {excepcion.Context.Parser.Row}).");
			}

			NewBulkMovimientoEquipoAEtapaPosteriorCsvModel modelo = new NewBulkMovimientoEquipoAEtapaPosteriorCsvModel()
			{
				Movimientos = modeloCsv.Select(e => new NewMovimientoEquipoAEtapaPosteriorCsvModel()
				{
					Esn = e.Esn.Trim(),
					Fecha = e.Fecha,
					Operario = e.Operario.Trim(),
					Observacion = e.Observacion.Trim()
				}).ToList()
			};

			return await GuardarAsync(modelo, fecha, usuario);
		}

		private async Task<Result> GuardarAsync(NewBulkMovimientoEquipoAEtapaPosteriorCsvModel modelo, DateTime fecha, string usuario)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewBulkMovimientoEquipoAEtapaPosteriorCsvModelValidator());

			if (errores is not null)
			{
				return new Result(ResultType.Invalid, errores);
			}

			await using (ReporteriaMovistarDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					try
					{
						List<TempEquipoMovimientoCsvEntity> entidades = modelo.ToEntitiesWithRelated(fecha, usuario);
						await unitOfWork.TempEquipoMovimientoCsvEntities.BatchDeleteCargaNoExitosaAsync();
						await unitOfWork.TempEquipoMovimientoCsvEntities.BulkInsertAsync(entidades);
						await dbContext.SPBulkInsertMovimientoEquipoEntityAsync(IdEtapaEmpaque, IdEtapaDespacho, fecha, usuario);
						return new Result();
					}
					catch (SqlException e) when (e.Number == 50000)
					{
						return new Result(ResultType.Invalid, e.Message);
					}
				}
			}
		}

		public async Task<Result<FileResult>> ExportarEjemploAsync()
		{
			return new Result<FileResult>(new FileResult()
			{
				Name = Helpers.ExportFormatHelper.GetBulkLoadFileName("empaque a despacho", DateTime.Now),
				Extension = FileExtensions.Csv,
				Content = await new CsvFileHandler().GetExampleAsync<MovimientoEquipoAEtapaPosteriorCsvModel>()
			});
		}
	}
}