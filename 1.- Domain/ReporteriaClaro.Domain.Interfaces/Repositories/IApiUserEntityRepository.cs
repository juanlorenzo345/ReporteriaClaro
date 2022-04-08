﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 29-11-2021 11:28:28 AM
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Domain.Models.Pagination;
using ReporteriaClaro.Domain.Models.Sorting;

namespace ReporteriaClaro.Domain.Interfaces.Repositories
{
    public partial interface IApiUserEntityRepository
    {
	    public Task<PagedResult<ApiUserEntity>> GetPaginadoAsync(PagerInfo pagerInfo, SortingInfo sortingInfo);
    }
}
