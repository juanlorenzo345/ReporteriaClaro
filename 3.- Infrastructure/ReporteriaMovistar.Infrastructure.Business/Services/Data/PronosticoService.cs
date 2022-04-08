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
//     Nombre: PronosticoService.cs
//     Fecha creación: 2021/10/29 at 06:15 PM
//     Fecha modificación: 2021/10/29 at 06:15 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporteriaMovistar.Application.Interfaces.Services.Data;
using ReporteriaMovistar.Application.Models.Input.Delete;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Input.Update;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Pagination;
using ReporteriaMovistar.Application.Models.Sorting;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Application.Models.Validation.Delete;
using ReporteriaMovistar.Application.Models.Validation.Insert;
using ReporteriaMovistar.Application.Models.Validation.Update;
using ReporteriaMovistar.Domain.Interfaces.Repositories;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;
using ReporteriaMovistar.Infrastructure.Data.DataProviders;

namespace ReporteriaMovistar.Infrastructure.Business.Services.Data
{
	public class PronosticoService : DatabaseServiceBase, IPronosticoService
	{
		public PronosticoService(IDbContextFactory<ReporteriaMovistarDbContext> dbContextFactory) : base(dbContextFactory, "el pronóstico")
		{
		}

		public async Task<Result> CrearPronosticoAsync(NewPronosticoModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewPronosticoModelValidator());

			if (errores is not null)
			{
				return new Result(ResultType.Invalid, errores);
			}

			await using (ReporteriaMovistarDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					await unitOfWork.BeginTransactionAsync();
					try
					{
						DateTime periodo = modelo.Periodo.Value;
						if (await unitOfWork.PronosticoEntities.ExistePronosticoAsync((short) periodo.Year, (byte) periodo.Month, modelo.Tecnologia.Id))
						{
							return new Result(ResultType.Invalid, "Ya existe el pronóstico para la tecnología y período especificado.");
						}

						PronosticoEntity entidad = modelo.ToEntity();
						await unitOfWork.PronosticoEntities.AddAsync(entidad);
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

		public async Task<Result> ModificarPronosticoAsync(UpdatePronosticoModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new UpdatePronosticoModelValidator());

			if (errores is not null)
			{
				return new Result(ResultType.Invalid, errores);
			}

			await using (ReporteriaMovistarDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					await unitOfWork.BeginTransactionAsync();
					try
					{
						PronosticoEntity entidad = await unitOfWork.PronosticoEntities.FindAsync(modelo.Id);
						if (entidad is null)
						{
							return new Result(ResultType.Invalid, base.MensajeEntidadNoEncontrada);
						}
						DateTime periodo = modelo.Periodo.Value;
						if (entidad.Ano != (short)periodo.Year && entidad.Mes != (byte)periodo.Month && entidad.TecnologiaId != modelo.Tecnologia.Id && await unitOfWork.PronosticoEntities.ExistePronosticoAsync((short)periodo.Year, (byte)periodo.Month, modelo.Tecnologia.Id))
						{
							return new Result(ResultType.Invalid, "Ya existe el pronóstico para la tecnología y período especificado.");
						}

						entidad.UpdateEntityFromModel(modelo);
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

		public async Task<Result> EliminarPronosticoAsync(DeleteModelBase<int> modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new DeleteModelValidatorBase<DeleteModelBase<int>, int>());

			if (errores is not null)
			{
				return new Result(ResultType.Invalid, errores);
			}

			await using (ReporteriaMovistarDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					await unitOfWork.BeginTransactionAsync();
					try
					{
						PronosticoEntity entidad = await unitOfWork.PronosticoEntities.FindAsync(modelo.Id);
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

		public async Task<Result<PronosticoEntityDto>> ObtenerPronosticoPorIdAsync(int id)
		{
			await using (ReporteriaMovistarDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					PronosticoEntity entidad = await unitOfWork.PronosticoEntities.FindConTecnologiaAsync(id);
					return new Result<PronosticoEntityDto>(entidad.ToDtoWithRelated(1));
				}
			}
		}

		public async Task<Result<PagedResult<PronosticoEntityDto>>> ObtenerListaPronosticosPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaMovistarDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					Domain.Models.Pagination.PagedResult<PronosticoEntity> entidades = await unitOfWork.PronosticoEntities.GetPaginadoAsync(!mostrarEliminados, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<PronosticoEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtosWithRelated(1)));
				}
			}
		}
	}
}