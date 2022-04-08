﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 02-11-2021 02:48:11 PM
//
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using ReporteriaMovistar.Domain.Interfaces.Repositories;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Domain.Models.Pagination;
using ReporteriaMovistar.Domain.Models.Sorting;
using ReporteriaMovistar.Infrastructure.Data.Extensions;

namespace ReporteriaMovistar.Infrastructure.Data.Repositories
{
    public partial class EtapaEstadoEntityRepository
    {
	    public async Task<bool> ExistePosicionAsync(int position)
	    {
		    return await this.objectSet.AnyAsync(e => e.Activo && e.Posicion == position);
	    }

	    public async Task BatchUpdatePosicionAsync(int position)
	    {
		    await this.objectSet.Where(e => e.Activo && e.Posicion >= position).BatchUpdateAsync(e => new EtapaEstadoEntity() { Posicion = e.Posicion + 1 });
	    }

	    public async Task<EtapaEstadoEntity> FindAsync(int id)
	    {
			IQueryable<EtapaEstadoEntity> consultaFiltrada = this.objectSet.Where(e => e.Activo && e.Id == id);
			return await consultaFiltrada.SingleOrDefaultAsync();
		}

	    public async Task<IEnumerable<EtapaEstadoEntity>> GetAsync()
	    {
			IQueryable<EtapaEstadoEntity> consultaFiltrada = this.objectSet.Where(e => e.Activo);
			return await consultaFiltrada.OrderBy(e => e.Posicion).ToListAsync();
		}

		public async Task<PagedResult<EtapaEstadoEntity>> GetPaginadoAsync(bool activeRecords, PagerInfo pagerInfo, SortingInfo sortingInfo)
	    {
			IQueryable<EtapaEstadoEntity> consultaFiltrada = this.objectSet.Where(e => e.Activo == activeRecords);

			consultaFiltrada = sortingInfo.ColumnName switch
			{
				"id" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Id),
				"estado" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Nombre),
				"posicion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Posicion),
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