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
//     Nombre: RolService.cs
//     Fecha creación: 2021/11/05 at 12:49 PM
//     Fecha modificación: 2021/11/05 at 12:49 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporteriaMovistar.Application.Interfaces.Services.Data;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Pagination;
using ReporteriaMovistar.Application.Models.Sorting;
using ReporteriaMovistar.Application.Models.Transfer;
using ReporteriaMovistar.Domain.Interfaces.Repositories;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Infrastructure.Business.Extensions;
using ReporteriaMovistar.Infrastructure.Data.DataProviders;

namespace ReporteriaMovistar.Infrastructure.Business.Services.Data
{
	public class RolService : DatabaseServiceBase, IRolService
	{
		public RolService(IDbContextFactory<ReporteriaMovistarDbContext> dbContextFactory) : base(dbContextFactory, "el rol")
		{
		}

		public async Task<Result<IEnumerable<IdentityRoleEntityDto>>> ObtenerListaRolesAsync(bool esSuperAdmin, string rol)
		{
			await using (ReporteriaMovistarDbContext dbContext = base.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					IEnumerable<IdentityRoleEntity> entidades = new List<IdentityRoleEntity>(0);

					if (esSuperAdmin)
					{
						entidades = await unitOfWork.IdentityRoleEntities.GetAvailableAsSuperAdminAsync(rol);
					}
					else
					{
						entidades = await unitOfWork.IdentityRoleEntities.GetAvailableAsAdminAsync(rol);
					}
					
					return new Result<IEnumerable<IdentityRoleEntityDto>>(entidades.ToDtos());
				}
			}
		}

		public async Task<Result<PagedResult<IdentityUserRoleEntityDto>>> ObtenerListaRolesPaginadoAsync(string idUsuario, PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaMovistarDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					Domain.Models.Pagination.PagedResult<IdentityUserRoleEntity> entidades = await unitOfWork.IdentityUserRoleEntities.GetPaginadoAsync(idUsuario, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<IdentityUserRoleEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtosWithRelated(1)));
				}
			}
		}
	}
}