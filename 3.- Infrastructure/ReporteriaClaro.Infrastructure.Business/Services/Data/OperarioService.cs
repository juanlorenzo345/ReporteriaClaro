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
//     Nombre: OperarioService.cs
//     Fecha creación: 2021/11/17 at 11:15 AM
//     Fecha modificación: 2021/11/17 at 11:15 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Application.Interfaces.Services.Data;
using ReporteriaClaro.Application.Models.Enums;
using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Input.Update;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Application.Models.Validation.Delete;
using ReporteriaClaro.Application.Models.Validation.Insert;
using ReporteriaClaro.Application.Models.Validation.Update;
using ReporteriaClaro.Domain.Interfaces.Repositories;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;
using ReporteriaClaro.Infrastructure.Data.DataProviders;

namespace ReporteriaClaro.Infrastructure.Business.Services.Data
{
	public class OperarioService : DatabaseServiceBase, IOperarioService
	{
		public OperarioService(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory) : base(dbContextFactory, "el operario")
		{
		}

		public async Task<Result> CrearOperarioAsync(NewOperarioModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewOperarioModelValidator());

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
						OperarioEntity entidad = modelo.ToEntity();
						await unitOfWork.OperarioEntities.AddAsync(entidad);
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

		public async Task<Result> ModificarOperarioAsync(UpdateOperarioModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new UpdateOperarioModelValidator());

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
						OperarioEntity entidad = await unitOfWork.OperarioEntities.FindAsync(modelo.Id);
						if (entidad is null)
						{
							return new Result(ResultType.Invalid, base.MensajeEntidadNoEncontrada);
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

		public async Task<Result> EliminarOperarioAsync(DeleteModelBase<int> modelo)
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
						OperarioEntity entidad = await unitOfWork.OperarioEntities.FindAsync(modelo.Id);
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

		public async Task<Result<OperarioEntityDto>> ObtenerOperarioPorIdAsync(int id)
		{
			await using (ReporteriaClaroDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					OperarioEntity entidad = await unitOfWork.OperarioEntities.FindAsync(id);
					return new Result<OperarioEntityDto>(entidad.ToDto());
				}
			}
		}

		public async Task<Result<IEnumerable<OperarioEntityDto>>> ObtenerListaOperariosAsync(string operario)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					IEnumerable<OperarioEntity> entidades = await unitOfWork.OperarioEntities.GetTop20Async(operario);
					return new Result<IEnumerable<OperarioEntityDto>>(entidades.ToDtos());
				}
			}
		}

		public async Task<Result<PagedResult<OperarioEntityDto>>> ObtenerListaOperariosPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					Domain.Models.Pagination.PagedResult<OperarioEntity> entidades = await unitOfWork.OperarioEntities.GetPaginadoAsync(!mostrarEliminados, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<OperarioEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtos()));
				}
			}
		}
	}
}