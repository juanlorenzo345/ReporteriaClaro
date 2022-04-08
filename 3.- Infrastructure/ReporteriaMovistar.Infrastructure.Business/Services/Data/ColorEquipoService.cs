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
//     Nombre: ColorEquipoService.cs
//     Fecha creación: 2021/10/29 at 06:07 PM
//     Fecha modificación: 2021/10/29 at 06:07 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReporteriaMovistar.Infrastructure.Business.Services.Data
{
	public class ColorEquipoService : DatabaseServiceBase, IColorEquipoService
	{
		public ColorEquipoService(IDbContextFactory<ReporteriaMovistarDbContext> dbContextFactory) : base(dbContextFactory, "el color")
		{
		}

		public async Task<Result> CrearColorAsync(NewColorEquipoModel modelo)
        {
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewColorEquipoModelValidator());

			if(errores is not null)
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
						EquipoColorEntity entidad = modelo.ToEntity();
						await unitOfWork.EquipoColorEntities.AddAsync(entidad);
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

		public async Task<Result> ModificarColorAsync(UpdateColorEquipoModel modelo)
        {
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new UpdateColorEquipoModelValidator());

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
						EquipoColorEntity entidad = await unitOfWork.EquipoColorEntities.FindAsync(modelo.Id);
						if(entidad is null)
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

		public async Task<Result> EliminarColorAsync(DeleteModelBase<int> modelo)
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
						EquipoColorEntity entidad = await unitOfWork.EquipoColorEntities.FindAsync(modelo.Id);
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

		public async Task<Result<EquipoColorEntityDto>> ObtenerColorPorIdAsync(int id)
		{
			await using (ReporteriaMovistarDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					EquipoColorEntity entidad = await unitOfWork.EquipoColorEntities.FindAsync(id);
					return new Result<EquipoColorEntityDto>(entidad.ToDto());
				}
			}
		}

		public async Task<Result<PagedResult<EquipoColorEntityDto>>> ObtenerListaColoresPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
        {
			await using (ReporteriaMovistarDbContext dbContext = base.DbContextFactory.CreateDbContext())
            {
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
                {
					Domain.Models.Pagination.PagedResult<EquipoColorEntity> entidades = await unitOfWork.EquipoColorEntities.GetPaginadoAsync(!mostrarEliminados, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<EquipoColorEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtos()));
                }
            }
        }
	}
}