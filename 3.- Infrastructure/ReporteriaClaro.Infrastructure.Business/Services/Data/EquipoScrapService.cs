using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Application.Interfaces.Services.Data;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaClaro.Infrastructure.Business.Services.Data
{
    public class EquipoScrapService : DatabaseServiceBase, IEquipoScrapService
    {
        public EquipoScrapService(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory) : base(dbContextFactory, "El equipo")
        { 
        }

        public async Task<Result<IEnumerable<EquipoScrapEntityDto>>> ObtenerListaEquiposAsync(string serie)
        {
            await using(ReporteriaClaroDbContext dbContext = this.DbContextFactory.CreateDbContext())
            {
                base.InitializeUnitOfWork(dbContext);
                using (IUnitOfWork unitOfwork = base.UnitOfWorkFactory.Create())
                {
                    IEnumerable<EquipoScrapEntity> entidades = await unitOfwork.EquipoScrapEntities.GetTop20Async(serie);
                    return new Result<IEnumerable<EquipoScrapEntityDto>>(entidades.ToDtosWithRelated(2));
                }
            }
        }

        public async Task<Result<PagedResult<EquipoScrapEntityDto>>> ObtenerListaEquiposPaginadoAsync(bool mostrarELiminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
        {
            await using (ReporteriaClaroDbContext dbContext = this.DbContextFactory.CreateDbContext())
            {
                base.InitializeUnitOfWork(dbContext);
                using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
                {
                    Domain.Models.Pagination.PagedResult<EquipoScrapEntity> entidades = await unitOfWork.EquipoScrapEntities.GetPaginadoAsync(!mostrarELiminados, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
                    return new Result<PagedResult<EquipoScrapEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtosWithRelated(2)));
                }
            }
        }

        public async Task<Result> CrearEquipoScrapAsync(NewEquipoScrapModel modelo)
        {
            IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewEquipoScrapModelValidator());

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
                        EquipoScrapEntity entidad = modelo.ToEntity();
                        await unitOfWork.EquipoScrapEntities.AddAsync(entidad);
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

        public async Task<Result> EliminarEquipoScrapAsync(DeleteModelBase<int> modelo)
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
                        EquipoScrapEntity entidad = await unitOfWork.EquipoScrapEntities.FindAsync(modelo.Id);
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
    }
}
