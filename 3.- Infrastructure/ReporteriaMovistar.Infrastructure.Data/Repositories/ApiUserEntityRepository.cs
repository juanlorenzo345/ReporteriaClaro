﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 29-11-2021 11:28:28 AM
//
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporteriaMovistar.Domain.Interfaces.Repositories;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Domain.Models.Pagination;
using ReporteriaMovistar.Domain.Models.Sorting;
using ReporteriaMovistar.Infrastructure.Data.Extensions;

namespace ReporteriaMovistar.Infrastructure.Data.Repositories
{
    public partial class ApiUserEntityRepository
    {
	    public async Task<PagedResult<ApiUserEntity>> GetPaginadoAsync(PagerInfo pagerInfo, SortingInfo sortingInfo)
	    {
			IQueryable<ApiUserEntity> consultaFiltrada = this.objectSet;

			consultaFiltrada = sortingInfo.ColumnName switch
			{
				"id" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Id),
				"comentario" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Comments),
				"fecha_creacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.CreatedAt),
				"usuario_creacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.CreatedBy),
				"fecha_modificacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.ModifiedAt),
				"usuario_modificacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.ModifiedBy),
				"fecha_eliminacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.DeactivatedAt),
				"usuario_eliminacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.DeactivatedBy),
				"razon_eliminacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.DeactivatedReason),
				"eliminado" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Active),
				_ => consultaFiltrada.OrderBy(e => e.Id)
			};

			return await consultaFiltrada.GetPagedAsync(pagerInfo.Page, pagerInfo.PageSize);
		}
    }
}
