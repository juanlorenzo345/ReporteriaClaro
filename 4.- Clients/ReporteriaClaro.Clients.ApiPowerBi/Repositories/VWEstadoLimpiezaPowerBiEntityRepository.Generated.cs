﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 03-12-2021 09:23:55 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using ReporteriaClaro.Clients.ApiPowerBi.Repositories.Interfaces;

namespace ReporteriaClaro.Clients.ApiPowerBi.Repositories
{
    public partial class VWEstadoLimpiezaPowerBiEntityRepository : EntityFrameworkRepository<ReporteriaClaro.Clients.ApiPowerBi.Models.VWEstadoLimpiezaPowerBiEntity>, IVWEstadoLimpiezaPowerBiEntityRepository
    {
        public VWEstadoLimpiezaPowerBiEntityRepository(ReporteriaClaro.Clients.ApiPowerBi.DataProviders.ReporteriaClaroDbContext context)
            : base(context)
        {
        }

        public virtual ICollection<ReporteriaClaro.Clients.ApiPowerBi.Models.VWEstadoLimpiezaPowerBiEntity> GetAll()
        {
            return objectSet.ToList();
        }

        public virtual ReporteriaClaro.Clients.ApiPowerBi.Models.VWEstadoLimpiezaPowerBiEntity GetByKey()
        {
            return null;
        }

        public new ReporteriaClaro.Clients.ApiPowerBi.DataProviders.ReporteriaClaroDbContext Context 
        {
            get
            {
                return (ReporteriaClaro.Clients.ApiPowerBi.DataProviders.ReporteriaClaroDbContext)base.Context;
            }
        }
    }
}