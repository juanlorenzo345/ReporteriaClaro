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
using System.Collections.Generic;

namespace ReporteriaClaro.Clients.ApiPowerBi.Repositories.Interfaces
{
    public partial interface IApiUserEntityRepository : IRepository<ReporteriaClaro.Clients.ApiPowerBi.Models.ApiUserEntity>
    {
        ICollection<ReporteriaClaro.Clients.ApiPowerBi.Models.ApiUserEntity> GetAll();
        ReporteriaClaro.Clients.ApiPowerBi.Models.ApiUserEntity GetByKey(int _Id);
    }
}
