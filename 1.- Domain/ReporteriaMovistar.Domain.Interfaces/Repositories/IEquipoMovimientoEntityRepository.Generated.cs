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

namespace ReporteriaMovistar.Domain.Interfaces.Repositories
{
    public partial interface IEquipoMovimientoEntityRepository : IRepository<ReporteriaMovistar.Domain.Models.Entities.EquipoMovimientoEntity>
    {
        ICollection<ReporteriaMovistar.Domain.Models.Entities.EquipoMovimientoEntity> GetAll();
        ReporteriaMovistar.Domain.Models.Entities.EquipoMovimientoEntity GetByKey(int _Id);
    }
}
