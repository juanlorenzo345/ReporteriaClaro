﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 26-10-2021 09:00:55 AM
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
    public partial interface IIdentityUserEntityRepository
    {
	    public Task<PagedResult<IdentityUserEntity>> GetPaginadoAsync(string user, PagerInfo pagerInfo, SortingInfo sortingInfo);
    }
}
