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
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Infrastructure.Business
// Info archivo:
//     Nombre: MovimientoEtiquetadoACalidadService.cs
//     Fecha creación: 2021/12/07 at 06:19 PM
//     Fecha modificación: 2021/12/07 at 06:19 PM
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
using ReporteriaClaro.Application.Interfaces.Services.Data;
using ReporteriaClaro.Application.Models.Enums;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Application.Models.Validation.Insert;
using ReporteriaClaro.Domain.Interfaces.Repositories;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Csv;
using ReporteriaClaro.Infrastructure.Business.Csv.Models;
using ReporteriaClaro.Infrastructure.Business.File;
using ReporteriaClaro.Infrastructure.Data.DataProviders;
using MissingFieldException = CsvHelper.MissingFieldException;

namespace ReporteriaClaro.Infrastructure.Business.Services.Data
{
	public class MovimientoEtiquetadoACalidadService : DatabaseServiceBase, IMovimientoEtiquetadoACalidadService
	{
		private const int IdEtapaEtiquetado = (int) Etapa.Etiquetado;

		private const int IdEtapaControlCalidad = (int) Etapa.ControlCalidad;

		public MovimientoEtiquetadoACalidadService(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory) : base(dbContextFactory, "")
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

			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					try
					{
						List<TempEquipoMovimientoCsvEntity> entidades = modelo.ToEntitiesWithRelated(fecha, usuario);
						await unitOfWork.TempEquipoMovimientoCsvEntities.BatchDeleteCargaNoExitosaAsync();
						await unitOfWork.TempEquipoMovimientoCsvEntities.BulkInsertAsync(entidades);
						await dbContext.SPBulkInsertMovimientoEquipoEntityAsync(IdEtapaEtiquetado, IdEtapaControlCalidad, fecha, usuario);
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
				Name = Helpers.ExportFormatHelper.GetBulkLoadFileName("etiquetado a calidad", DateTime.Now),
				Extension = FileExtensions.Csv,
				Content = await new CsvFileHandler().GetExampleAsync<MovimientoEquipoAEtapaPosteriorCsvModel>()
			});
		}
	}
}