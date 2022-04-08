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
using ReporteriaClaro.Application.Interfaces.Services.Data;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;
using ReporteriaClaro.Domain.Interfaces.Repositories;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Infrastructure.Business.Extensions;
using ReporteriaClaro.Infrastructure.Data.DataProviders;

namespace ReporteriaClaro.Infrastructure.Business.Services.Data
{
	public class EquipoService : DatabaseServiceBase, IEquipoService
	{
		public EquipoService(IDbContextFactory<ReporteriaClaroDbContext> dbContextFactory) : base(dbContextFactory, "el equipo")
		{
		}

		public async
		Task<Result<(int equiposComparados, int equiposInsertados, int equiposActualizados, DateTime fechaInicioRecepcion, DateTime fechaTerminoRecepcion)>> EjecutarMergeEquipoFullstarAsync(DateTime fecha, string usuario)
		{
			await using (ReporteriaClaroDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				Tuple<int?, int?, int?, DateTime?, DateTime?> resultado = await dbContext.SPMergeEquipoEntityAsync(fecha.Date, fecha, usuario, null, null, null, null, null);
				return new Result<(int equiposComparados, int equiposInsertados, int equiposActualizados, DateTime fechaInicioRecepcion, DateTime fechaTerminoRecepcion)>((resultado.Item1.Value, resultado.Item2.Value, resultado.Item3.Value, resultado.Item4.Value, resultado.Item5.Value));
			}
		}

		public async Task<Result<IEnumerable<SPInformacionEquipoEntityResultDto>>> ObtenerListaEquiposAsync(string esn)
		{
			await using (ReporteriaClaroDbContext dbContext = this.DbContextFactory.CreateDbContext())
			{
				IEnumerable<SPInformacionEquipoEntityResult> entidades = await dbContext.SPInformacionEquipoEntityAsync(esn);
				return new Result<IEnumerable<SPInformacionEquipoEntityResultDto>>(entidades.ToDtos());
			}
		}

		public async Task<Result<PagedResult<EquipoEntityDto>>> ObtenerListaEquiposPaginadoAsync(string esn, bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo)
		{
			await using (ReporteriaClaroDbContext dbContext = this.DbContextFactory.CreateDbContext())
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