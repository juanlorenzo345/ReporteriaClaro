﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 26-10-2021 03:18:16 PM
//
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReporteriaMovistar.Domain.Interfaces.Repositories;
using ReporteriaMovistar.Domain.Models.Entities;
using ReporteriaMovistar.Domain.Models.Pagination;
using ReporteriaMovistar.Domain.Models.Sorting;
using ReporteriaMovistar.Infrastructure.Data.Extensions;

namespace ReporteriaMovistar.Infrastructure.Data.Repositories
{
    public partial class EtapaEntityRepository
    {
	    public async Task<bool> ExistePosicionAsync(int position)
	    {
			return await this.objectSet.AnyAsync(e => e.Activo && e.Posicion == position);
		}

	    public async Task BatchUpdatePosicionAsync(int position)
	    {
			await this.objectSet.Where(e => e.Activo && e.Posicion >= position).BatchUpdateAsync(e => new EtapaEntity() { Posicion = e.Posicion + 1 });
		}

	    public async Task<EtapaEntity> FindConZonaAsync(int id)
	    {
			IIncludableQueryable<EtapaEntity, ZonaEntity> consultaJoin = this.objectSet
				.Include(e => e.ZonaEntity);

			IQueryable<EtapaEntity> consultaFiltrada = consultaJoin.Where(e => e.Activo && e.Id == id);
			return await consultaFiltrada.SingleOrDefaultAsync();
	    }

	    public async Task<IEnumerable<EtapaEntity>> GetConZonaAsync()
	    {
			IIncludableQueryable<EtapaEntity, ZonaEntity> consultaJoin = this.objectSet
				.Include(e => e.ZonaEntity);

			IQueryable<EtapaEntity> consultaFiltrada = consultaJoin.Where(e => e.Activo);
			return await consultaFiltrada.ToListAsync();
		}

	    public async Task<PagedResult<EtapaEntity>> GetPaginadoAsync(bool activeRecords, PagerInfo pagerInfo, SortingInfo sortingInfo)
	    {
		    IIncludableQueryable<EtapaEntity, ZonaEntity> consultaJoin = this.objectSet
				.Include(e => e.ZonaEntity);

			IQueryable<EtapaEntity> consultaFiltrada = consultaJoin.Where(e => e.Activo == activeRecords);

			consultaFiltrada = sortingInfo.ColumnName switch
			{
				"id" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Id),
				"etapa" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Nombre),
				"posicion" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.Posicion),
				"zona" => consultaFiltrada.SortBy(sortingInfo.Direction, e => e.ZonaEntity.Nombre),
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
