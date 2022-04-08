﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 26-10-2021 09:00:55 AM
//
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReporteriaClaro.Domain.Interfaces.Repositories;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Domain.Models.Pagination;
using ReporteriaClaro.Domain.Models.Sorting;
using ReporteriaClaro.Infrastructure.Data.Extensions;

namespace ReporteriaClaro.Infrastructure.Data.Repositories
{
    public partial class IdentityUserExceptionLogEntityRepository
    {
	    public async Task<PagedResult<IdentityUserExceptionLogEntity>> GetPaginadoAsync(PagerInfo pagerInfo, SortingInfo sortingInfo)
	    {
		    IIncludableQueryable<IdentityUserExceptionLogEntity, IdentityUserEntity> consultaJoin = this.objectSet
		    .Include(e => e.IdentityUserEntity);

		    IQueryable<IdentityUserExceptionLogEntity> consultaFiltrada = consultaJoin;

		    consultaFiltrada = sortingInfo.ColumnName switch
		    {
			    "id" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Id),
			    "usuario" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.IdentityUserEntity.UserName),
			    "fecha_creacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.CreatedAt),
			    "mensaje" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Message),
				"tipo" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Type),
				"origen" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Source),
				"url" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Url),
				_ => consultaFiltrada.OrderBy(e => e.CreatedAt)
		    };

			return await consultaFiltrada.GetPagedAsync(pagerInfo.Page, pagerInfo.PageSize);
		}
    }
}
