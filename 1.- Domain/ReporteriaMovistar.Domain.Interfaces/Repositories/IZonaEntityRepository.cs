﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 26-10-2021 03:18:16 PM
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Domain.Models.Pagination;
using ReporteriaMovistar.Domain.Models.Sorting;

namespace ReporteriaMovistar.Domain.Interfaces.Repositories
{
    public partial interface IZonaEntityRepository
    {
	    public Task<ZonaEntity> FindAsync(int id);

	    public Task<IEnumerable<ZonaEntity>> GetAsync();

	    public Task<PagedResult<ZonaEntity>> GetPaginadoAsync(bool activeRecords, PagerInfo pagerInfo, SortingInfo sortingInfo);
    }
}
