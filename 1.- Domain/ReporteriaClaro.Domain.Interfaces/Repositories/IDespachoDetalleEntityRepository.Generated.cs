﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 10-12-2021 02:28:28 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace ReporteriaClaro.Domain.Interfaces.Repositories
{
    public partial interface IDespachoDetalleEntityRepository : IRepository<ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity>
    {
        ICollection<ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity> GetAll();
        ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity GetByKey(int _Id);
    }
}
