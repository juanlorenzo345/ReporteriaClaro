﻿//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 22-11-2021 11:44:14 AM
//
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Domain.Interfaces.Repositories;

namespace ReporteriaClaro.Infrastructure.Data.Repositories
{
    public partial class TempDespachoCsvEntityRepository
    {
	    public async Task BatchDeleteCargaNoExitosaAsync()
	    {
		    await this.objectSet.Where(e => !e.CargaExitosa).BatchDeleteAsync();
	    }
    }
}