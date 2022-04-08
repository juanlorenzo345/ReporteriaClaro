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
//     Nombre: EncabezadoDespachoService.CargaMasiva.cs
//     Fecha creación: 2021/11/18 at 01:07 PM
//     Fecha modificación: 2021/11/18 at 01:07 PM
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
	public partial class EncabezadoDespachoService
	{
		public async Task<Result> ImportarArchivoAsync(Stream archivo, DateTime fecha, string usuario)
		{
			List<DespachoCsvModel> modeloCsv = new List<DespachoCsvModel>();
			try
			{
				modeloCsv = new CsvFileHandler().GetFileContent<DespachoCsvModel>(archivo);
			}
			catch (MissingFieldException excepcion)
			{
				return new Result(ResultType.Invalid, $"No se encontró la columna {excepcion.Context.Reader.CurrentIndex + 1}.");
			}
			catch (TypeConverterException excepcion)
			{
				return new Result(ResultType.Invalid, $"No se pudo procesar el valor '{excepcion.Text}' como {CsvFileHandler.GetAliasType(excepcion.MemberMapData)} en '{excepcion.Context.Parser.RawRecord}' (columna {excepcion.Context.Reader.CurrentIndex + 1}, fila {excepcion.Context.Parser.Row}).");
			}

			NewBulkDespachoCsvModel modelo = new NewBulkDespachoCsvModel()
			{
				Despachos = modeloCsv.Select(d => new NewDespachoCsvModel()
				{
					Esn = d.Esn.Trim(),
					Fecha = d.Fecha,
					Operario = d.Operario.Trim(),
					Caja = d.Caja,
					Pallet = d.Pallet,
					Pintura = d.Pintura,
					ProcesoFinalizado = d.ProcesoFinalizado,
					Derivada = d.Derivada?.Trim(),
					Guia = d.Guia.Trim(),
					EstadoDespacho = d.EstadoDespacho.Trim(),
					FuentePoder = d.FuentePoder.Trim(),
					Utp = d.Utp.Trim(),
					ControlRemoto = d.ControlRemoto.Trim(),
					Hdmi = d.Hdmi.Trim(),
					Rca = d.Rca.Trim()
				}).ToList()
			};

			return await GuardarDespachosAsync(modelo, fecha, usuario);
		}

		private async Task<Result> GuardarDespachosAsync(NewBulkDespachoCsvModel modelo, DateTime fecha, string usuario)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewBulkDespachoCsvModelValidator());

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
						List<TempDespachoCsvEntity> entidades = modelo.ToEntitiesWithRelated(fecha, usuario);
						await unitOfWork.TempDespachoCsvEntities.BatchDeleteCargaNoExitosaAsync();
						await unitOfWork.TempDespachoCsvEntities.BulkInsertAsync(entidades);
						await dbContext.SPMergeDespachoYEquipoEntityAsync(fecha, usuario);
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
				Name = Helpers.ExportFormatHelper.GetBulkLoadFileName("despacho", DateTime.Now),
				Extension = FileExtensions.Csv,
				Content = await new CsvFileHandler().GetExampleAsync<DespachoCsvModel>()
			});
		}
	}
}