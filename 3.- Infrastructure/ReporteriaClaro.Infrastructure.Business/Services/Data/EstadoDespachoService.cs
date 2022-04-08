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
//     Nombre: EstadoGuiaService.cs
//     Fecha creación: 2021/10/29 at 06:09 PM
//     Fecha modificación: 2021/10/29 at 06:09 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Application.Interfaces.Services.Data;
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
using System.Collections.Generic;
using System.Threading.Tasks;
using DespachoEstadoEntityDto = ReporteriaClaro.Application.Models.Transfer.DespachoEstadoEntityDto;

namespace ReporteriaClaro.Infrastructure.Business.Services.Data
{
	public class EstadoDespachoService : DatabaseServiceBase, IEstadoDespachoService
	{
		public EstadoDespachoService(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory) : base(dbContextFactory, "el estado")
		{
		}

		public async Task<Result> CrearEstadoAsync(NewEstadoDespachoModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewEstadoDespachoModelValidator());

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
						if (await unitOfWork.DespachoEstadoEntities.ExistePosicionAsync(modelo.Posicion))
						{
							await unitOfWork.DespachoEstadoEntities.BatchUpdatePosicionAsync(modelo.Posicion);
						}

						DespachoEstadoEntity entidad = modelo.ToEntity();
						await unitOfWork.DespachoEstadoEntities.AddAsync(entidad);
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

		public async Task<Result> ModificarEstadoAsync(UpdateEstadoDespachoModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new UpdateEstadoDespachoModelValidator());

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
						if (await unitOfWork.DespachoEstadoEntities.ExistePosicionAsync(modelo.Posicion))
						{
							await unitOfWork.DespachoEstadoEntities.BatchUpdatePosicionAsync(modelo.Posicion);
						}

						DespachoEstadoEntity entidad = await unitOfWork.DespachoEstadoEntities.FindAsync(modelo.Id);
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

		public async Task<Result> EliminarEstadoAsync(DeleteModelBase<int> modelo)
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
						DespachoEstadoEntity entidad = await unitOfWork.DespachoEstadoEntities.FindAsync(modelo.Id);
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

		public async Task<Result<DespachoEstadoEntityDto>> ObtenerEstadoPorIdAsync(int id)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					DespachoEstadoEntity entidad = await unitOfWork.DespachoEstadoEntities.FindAsync(id);
					return new Result<DespachoEstadoEntityDto>(entidad.ToDto());
				}
			}
		}

		public async Task<Result<IEnumerable<DespachoEstadoEntityDto>>> ObtenerListaEstadosAsync()
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					IEnumerable<DespachoEstadoEntity> entidades = await unitOfWork.DespachoEstadoEntities.GetAsync();
					return new Result<IEnumerable<DespachoEstadoEntityDto>>(entidades.ToDtos());
				}
			}
		}

		public async Task<Result<PagedResult<DespachoEstadoEntityDto>>> ObtenerListaEstadosPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					Domain.Models.Pagination.PagedResult<DespachoEstadoEntity> entidades = await unitOfWork.DespachoEstadoEntities.GetPaginadoAsync(!mostrarEliminados, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<DespachoEstadoEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtos()));
				}
			}
		}
	}
}