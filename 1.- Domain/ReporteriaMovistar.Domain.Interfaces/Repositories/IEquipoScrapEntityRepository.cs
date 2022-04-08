﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: jue. 11 nov. 2021 9:55:43
//
//------------------------------------------------------------------------------
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Domain.Models.Pagination;
using ReporteriaMovistar.Domain.Models.Sorting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReporteriaMovistar.Domain.Interfaces.Repositories
{
    public partial interface IEquipoScrapEntityRepository
    {
        public Task<IEnumerable<EquipoScrapEntity>> GetTop20Async(string serie);

        public Task<PagedResult<EquipoScrapEntity>> GetPaginadoAsync(bool activeRecords, PagerInfo pagerInfo, SortingInfo sortingInfo);
    }
}
