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
//     Nombre: EquipoService.cs
//     Fecha creación: 2021/11/08 at 01:21 PM
//     Fecha modificación: 2021/11/08 at 01:21 PM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using System;
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
	public class EquipoService : DatabaseServiceBase, IEquipoService
	{
		public EquipoService(IDbContextFactory<ReporteriaMovistarDbContext> dbContextFactory) : base(dbContextFactory, "el equipo")
		{
		}

		public async
		Task<Result<(int equiposComparados, int equiposInsertados, int equiposActualizados, DateTime fechaInicioRecepcion, DateTime fechaTerminoRecepcion)>> EjecutarMergeEquipoFullstarAsync(DateTime fecha, string usuario)
		{
			await using (ReporteriaMovistarDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				Tuple<int?, int?, int?, DateTime?, DateTime?> resultado = await dbContext.SPMergeEquipoEntityAsync(fecha.Date, fecha, usuario, null, null, null, null, null);
				return new Result<(int equiposComparados, int equiposInsertados, int equiposActualizados, DateTime fechaInicioRecepcion, DateTime fechaTerminoRecepcion)>((resultado.Item1.Value, resultado.Item2.Value, resultado.Item3.Value, resultado.Item4.Value, resultado.Item5.Value));
			}
		}

		public async Task<Result<IEnumerable<SPInformacionEquipoEntityResultDto>>> ObtenerListaEquiposAsync(string esn)
		{
			await using (ReporteriaMovistarDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				IEnumerable<SPInformacionEquipoEntityResult> entidades = await dbContext.SPInformacionEquipoEntityAsync(esn);
				return new Result<IEnumerable<SPInformacionEquipoEntityResultDto>>(entidades.ToDtos());
			}
		}

		public async Task<Result<PagedResult<EquipoEntityDto>>> ObtenerListaEquiposPaginadoAsync(string esn, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaMovistarDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				base.InitializeUnitOfWork(dbContext);
				using (IUnitOfWork unitOfWork = base.UnitOfWorkFactory.Create())
				{
					Domain.Models.Pagination.PagedResult<EquipoEntity> entidades = await unitOfWork.EquipoEntities.GetPaginadoAsync(esn, !mostrarEliminados, pagerInfo.ToDomainPager(), sortingInfo.ToDomainSorting());
					return new Result<PagedResult<EquipoEntityDto>>(entidades.ToPagedDto(entidades.Results.ToDtosWithRelated(2)));
				}
			}
		}
	}
}