﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 02-11-2021 02:48:11 PM
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
    public partial interface IComponenteEstadoEntityRepository
    {
	    public Task<bool> ExistePosicionAsync(int position);

	    public Task BatchUpdatePosicionAsync(int position);

	    public Task<ComponenteEstadoEntity> FindAsync(int id);

        public Task<IEnumerable<ComponenteEstadoEntity>> GetAsync();

        public Task<PagedResult<ComponenteEstadoEntity>> GetPaginadoAsync(bool activeRecords, PagerInfo pagerInfo, SortingInfo sortingInfo);
    }
}
