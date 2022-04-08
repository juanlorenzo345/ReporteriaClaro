﻿#region Header
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
//     Nombre: MovimientoEquipoService.cs
//     Fecha creación: 2021/11/09 at 10:46 AM
//     Fecha modificación: 2021/11/09 at 10:46 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Application.Interfaces.Services.Data;
using ReporteriaClaro.Application.Interfaces.Services.File;
using ReporteriaClaro.Application.Models.Enums;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Application.Models.Validation.Delete;
using ReporteriaClaro.Application.Models.Validation.Insert;
using ReporteriaClaro.Domain.Interfaces.Repositories;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;
using ReporteriaClaro.Infrastructure.Data.DataProviders;

namespace ReporteriaClaro.Infrastructure.Business.Services.Data
{
	public partial class MovimientoEquipoService : DatabaseServiceBase, IMovimientoEquipoService
	{
		public MovimientoEquipoService(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory) : base(dbContextFactory, "el movimiento")
		{
		}

		public async Task<Result> CrearMovimientoBulkAsync(NewBulkMovimientoEquipoModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewBulkMovimientoEquipoModelValidator());

			if (errores is not null)
			{
				return new Result(ResultType.Invalid, errores);
			}

			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					await unitOfWork.BeginTransactionAsync();
					try
					{
						List<EquipoMovimientoEntity> entidades = modelo.ToEntities();
						await unitOfWork.EquipoMovimientoEntities.BulkInsertAsync(entidades);
						await unitOfWork.AutoCommitAsync();
						unitOfWork.CommitTransaction();
						return new Result();
					}
					catch
					{
						unitOfWork.RollbackTransaction();
						throw;
					}
				}
			}
		}

		public async Task<Result> EliminarMovimientoAsync(DeleteModelBase<int> modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new DeleteModelValidatorBase<DeleteModelBase<int>, int>());

			if (errores is not null)
			{
				return new Result(ResultType.Invalid, errores);
			}

			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					await unitOfWork.BeginTransactionAsync();
					try
					{
						EquipoMovimientoEntity entidad = await unitOfWork.EquipoMovimientoEntities.FindAsync(modelo.Id);
						if (entidad is null)
						{
							return new Result(ResultType.Invalid, base.MensajeEntidadNoEncontrada);
						}

						entidad.SetDeletedInfo(modelo);
						await unitOfWork.AutoCommitAsync();

						unitOfWork.CommitTransaction();
						return new Result();
					}
					catch
					{
						unitOfWork.RollbackTransaction();
						throw;
					}
				}
			}
		}

		public async Task<Result<SPUltimoOperarioEtapaEntityResultDto>> ObtenerUltimoOperarioEtapaAsync(int idEquipo, int idEtapa)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				List<SPUltimoOperarioEtapaEntityResult> entidades = await dbContext.SPUltimoOperarioEtapaEntityAsync(idEquipo, idEtapa);
				return new Result<SPUltimoOperarioEtapaEntityResultDto>(entidades.Count > 0 ? entidades[0].ToDto() : null);
			}
		}

		public async Task<Result<SPSeguimientoEquipoEntityResultDto>> ObtenerSeguimientoEquipoAsync(string esn)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				List<SPSeguimientoEquipoEntityResult> entidades = await dbContext.SPSeguimientoEquipoEntityAsync(esn);
				return new Result<SPSeguimientoEquipoEntityResultDto>(entidades.Count > 0 ? entidades[0].ToDto() : null);
			}
		}

		public async Task<Result<SPSeguimientoUltimoMovimientoEntityResultDto>> ObtenerSeguimientoUltimoMovimientoAsync(string esn)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				List<SPSeguimientoUltimoMovimientoEntityResult> entidades = await dbContext.SPSeguimientoUltimoMovimientoEntityAsync(esn);
				return new Result<SPSeguimientoUltimoMovimientoEntityResultDto>(entidades.Count > 0 ? entidades[0].ToDto() : null);
			}
		}

		public async Task<Result<SPSeguimientoDespachoEntityResultDto>> ObtenerSeguimientoDespachoAsync(string esn)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				List<SPSeguimientoDespachoEntityResult> entidades = await dbContext.SPSeguimientoDespachoEntityAsync(esn);
				return new Result<SPSeguimientoDespachoEntityResultDto>(entidades.Count > 0 ? entidades[0].ToDto() : null);
			}
		}

		public async Task<Result<IEnumerable<VWMovimientoEquipoEntityDto>>> ObtenerListaMovimientosPorEsnPaginadoAsync(string esn, bool mostrarEliminados)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					IEnumerable<VWMovimientoEquipoEntity> entidades = await unitOfWork.VWMovimientoEquipoEntities.GetByEsnPaginadoAsync(esn, !mostrarEliminados);
					return new Result<IEnumerable<VWMovimientoEquipoEntityDto>>(entidades.ToDtos());
				}
			}
		}

		public async Task<Result<PagedResult<VWMovimientoEquipoEntityDto>>> ObtenerListaMovimientosPaginadoAsync(string esn, Etapa etapaOrigen, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					Domain.Models.Pagination.PagedResult<VWMovimientoEquipoEntity> entidades = await unitOfWork.VWMovimientoEquipoEntities.GetByEtapaOrigenPaginadoAsync(esn, (int) etapaOrigen, !mostrarEliminados, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<VWMovimientoEquipoEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtos()));
				}
			}
		}

		public async Task<Result<PagedResult<VWMovimientoEquipoEntityDto>>> ObtenerListaMovimientosScrapPaginadoAsync(string esn, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					Domain.Models.Pagination.PagedResult<VWMovimientoEquipoEntity> entidades = await unitOfWork.VWMovimientoEquipoEntities.GetByEtapaDestinoPaginadoAsync(esn, (int) Etapa.Scrap, !mostrarEliminados, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<VWMovimientoEquipoEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtos()));
				}
			}
		}
	}
}