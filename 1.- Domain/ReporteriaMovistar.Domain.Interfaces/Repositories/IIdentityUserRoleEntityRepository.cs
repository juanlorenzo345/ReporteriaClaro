﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 26-10-2021 09:00:55 AM
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
    public partial interface IIdentityUserRoleEntityRepository
    {
	    public Task<PagedResult<IdentityUserRoleEntity>> GetPaginadoAsync(string userId, PagerInfo pagerInfo, SortingInfo sortingInfo);
    }
}
