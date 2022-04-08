﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 28-10-2021 03:52:54 PM
//
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Domain.Interfaces.Repositories;
using ReporteriaClaro.Domain.Models.Entities;
using ReporteriaClaro.Domain.Models.Pagination;
using ReporteriaClaro.Domain.Models.Sorting;
using ReporteriaClaro.Infrastructure.Data.Extensions;

namespace ReporteriaClaro.Infrastructure.Data.Repositories
{
    public partial class EquipoTecnologiaEntityRepository
    {
	    public async Task<EquipoTecnologiaEntity> FindAsync(int id)
	    {
			IQueryable<EquipoTecnologiaEntity> consultaFiltrada = this.objectSet.Where(e => e.Activo && e.Id == id);
		    return await consultaFiltrada.SingleOrDefaultAsync();
		}

	    public async Task<IEnumerable<EquipoTecnologiaEntity>> GetAsync()
	    {
		    IQueryable<EquipoTecnologiaEntity> consultaFiltrada = this.objectSet.Where(e => e.Activo);
		    return await consultaFiltrada.OrderBy(e => e.Nombre).ToListAsync();
	    }

	    public async Task<PagedResult<EquipoTecnologiaEntity>> GetPaginadoAsync(bool activeRecords, PagerInfo pagerInfo, SortingInfo sortingInfo)
	    {
		    IQueryable<EquipoTecnologiaEntity> consultaFiltrada = this.objectSet.Where(e => e.Activo == activeRecords);

		    consultaFiltrada = sortingInfo.ColumnName switch
		    {
			    "id" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Id),
			    "tecnologia" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Nombre),
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
