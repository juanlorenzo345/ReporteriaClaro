﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 06-12-2021 10:35:37 AM
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
    public partial interface IEtapaSecuenciaEntityRepository
    {
	    public Task<EtapaSecuenciaEntity> FindAsync(int id);
        
	    public Task<IEnumerable<EtapaSecuenciaEntity>> GetListaEtapaPorIdOrigenAsync(int idOrigen);

        public Task<PagedResult<EtapaSecuenciaEntity>> GetPaginadoAsync(bool activeRecords, PagerInfo pagerInfo, SortingInfo sortingInfo);
    }
}