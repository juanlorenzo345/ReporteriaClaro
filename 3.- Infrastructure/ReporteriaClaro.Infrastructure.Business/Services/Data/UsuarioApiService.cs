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
//     Nombre: UsuarioApiService.cs
//     Fecha creación: 2021/11/29 at 12:38 PM
//     Fecha modificación: 2021/11/29 at 12:38 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
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
using ReporteriaClaro.Infrastructure.Business.Helpers;
using ReporteriaClaro.Infrastructure.Data.DataProviders;

namespace ReporteriaClaro.Infrastructure.Business.Services.Data
{
	public class UsuarioApiService : DatabaseServiceBase, IUsuarioApiService
	{
		public UsuarioApiService(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory) : base(dbContextFactory, "el usuario")
		{
		}

		public async Task<Result<string>> CrearUsuarioAsync(NewUsuarioApiModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new NewUsuarioApiModelValidator());

			if (errores is not null)
			{
				return new Result<string>(ResultType.Invalid, errores);
			}

			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					await unitOfWork.BeginTransactionAsync();
					try
					{
						string apiKey = CryptographyUtils.GenerateApiKey();
						string keyHash = CryptographyUtils.HashApiKey(apiKey);
						ApiUserEntity entidad = modelo.ToEntity(keyHash);
						await unitOfWork.ApiUserEntities.AddAsync(entidad);
						await unitOfWork.AutoCommitAsync();
						unitOfWork.CommitTransaction();
						return new Result<string>(apiKey);
					}
					catch
					{
						unitOfWork.RollbackTransaction();
						throw;
					}
				}
			}
		}

		public async Task<Result> ModificarUsuarioAsync(UpdateUsuarioApiModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new UpdateUsuarioApiModelValidator());

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
						ApiUserEntity entidad = await unitOfWork.ApiUserEntities.FindAsync(modelo.Id);
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

		public async Task<Result> EliminarUsuarioAsync(DeleteUsuarioApiModel modelo)
		{
			IEnumerable<string> errores = await base.ValidateAsync(modelo, new DeleteUsuarioApiModelValidator());

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
						ApiUserEntity entidad = await unitOfWork.ApiUserEntities.FindAsync(modelo.Id);
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

		public async Task<Result<ApiUserEntityDto>> ObtenerUsuarioPorIdAsync(int id)
		{
			await using (ReporteriaClaroDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					ApiUserEntity entidad = await unitOfWork.ApiUserEntities.FindAsync(id);
					return new Result<ApiUserEntityDto>(entidad.ToDto());
				}
			}
		}

		public async Task<Result<PagedResult<ApiUserEntityDto>>> ObtenerListaUsuariosPaginadoAsync(PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaClaroDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					Domain.Models.Pagination.PagedResult<ApiUserEntity> entidades = await unitOfWork.ApiUserEntities.GetPaginadoAsync(pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<ApiUserEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtos()));
				}
			}
		}
	}
}