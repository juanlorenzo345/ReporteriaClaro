﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 07-12-2021 11:41:42 AM
//
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using ReporteriaMovistar.Domain.Interfaces.Repositories;

namespace ReporteriaMovistar.Infrastructure.Data.Repositories
{
    public partial class TempEquipoMovimientoCsvEntityRepository
    {
	    public async Task BatchDeleteCargaNoExitosaAsync()
	    { 
		    await this.objectSet.Where(e => !e.CargaExitosa).BatchDeleteAsync();
		}
    }
}
