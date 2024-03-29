﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 06-12-2021 10:35:37 AM
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
    public partial class EtapaSecuenciaEntityRepository
    {
	    public async Task<EtapaSecuenciaEntity> FindAsync(int id)
	    {
			IQueryable<EtapaSecuenciaEntity> consultaFiltrada = this.objectSet.Where(e => e.Activo && e.Id == id);
			return await consultaFiltrada.SingleOrDefaultAsync();
		}

	    public async Task<IEnumerable<EtapaSecuenciaEntity>> GetListaEtapaPorIdOrigenAsync(int idOrigen)
	    {
		    IIncludableQueryable<EtapaSecuenciaEntity, ZonaEntity> consultaJoin = this.objectSet
				.Include(e => e.EtapaEntity_EtapaAnteriorPosteriorId)
				.ThenInclude(e => e.ZonaEntity);

			IQueryable<EtapaSecuenciaEntity> consultaFiltrada = consultaJoin.Where(e => e.Activo && e.EtapaEntity_EtapaAnteriorPosteriorId.Activo && e.EtapaId == idOrigen);

			return await consultaFiltrada.ToListAsync();
	    }

	    public async Task<PagedResult<EtapaSecuenciaEntity>> GetPaginadoAsync(bool activeRecords, PagerInfo pagerInfo, SortingInfo sortingInfo)
	    {
		    IIncludableQueryable<EtapaSecuenciaEntity, EtapaEntity> consultaJoin = this.objectSet
			    .Include(e => e.EtapaEntity_EtapaId)
			    .Include(e => e.EtapaEntity_EtapaAnteriorPosteriorId);

			IQueryable<EtapaSecuenciaEntity> consultaFiltrada = consultaJoin.Where(e => e.Activo == activeRecords);

			consultaFiltrada = sortingInfo.ColumnName switch
			{
				"id" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Id),
				"origen" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.EtapaEntity_EtapaId.Nombre),
				"destino" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.EtapaEntity_EtapaAnteriorPosteriorId.Nombre),
				"es_etapa_anterior" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.EsEtapaAnterior),
				"fecha_creacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.FechaCreacionRegistro),
				"usuario_creacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.UsuarioCreacionRegistro),
				"fecha_modificacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.FechaModificacionRegistro),
				"usuario_modificacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.UsuarioModificacionRegistro),
				"fecha_eliminacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.FechaEliminacionRegistro),
				"usuario_eliminacion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.UsuarioEliminacionRegistro),
				"eliminado" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Activo),
				_ => consultaFiltrada.OrderBy(e => e.Id)
			};

			return await consultaFiltrada.GetPagedAsync(pagerInfo.Page, pagerInfo.PageSize);
		}
    }
}
