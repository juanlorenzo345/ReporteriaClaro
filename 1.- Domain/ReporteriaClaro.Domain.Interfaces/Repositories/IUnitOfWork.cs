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

namespace ReporteriaClaro.Domain.Interfaces.Repositories
{
    public partial interface IUnitOfWork : IDisposable
    {
        IIdentityRoleEntityRepository IdentityRoleEntities { get; }
        IIdentityRoleClaimEntityRepository IdentityRoleClaimEntities { get; }
        IIdentityUserEntityRepository IdentityUserEntities { get; }
        IIdentityUserAccessLogEntityRepository IdentityUserAccessLogEntities { get; }
        IIdentityUserClaimEntityRepository IdentityUserClaimEntities { get; }
        IIdentityUserExceptionLogEntityRepository IdentityUserExceptionLogEntities { get; }
        IIdentityUserLoginEntityRepository IdentityUserLoginEntities { get; }
        IIdentityUserOperationLogEntityRepository IdentityUserOperationLogEntities { get; }
        IIdentityUserRoleEntityRepository IdentityUserRoleEntities { get; }
        IIdentityUserTokenEntityRepository IdentityUserTokenEntities { get; }
        IEFMigrationsHistoryEntityRepository EFMigrationsHistoryEntities { get; }
        IEquipoColorEntityRepository EquipoColorEntities { get; }
        IEquipoMarcaEntityRepository EquipoMarcaEntities { get; }
        IEquipoModeloEntityRepository EquipoModeloEntities { get; }
        IEquipoMovimientoEntityRepository EquipoMovimientoEntities { get; }
        IEtapaEntityRepository EtapaEntities { get; }
        IComponenteEstadoEntityRepository ComponenteEstadoEntities { get; }
        IDespachoEstadoEntityRepository DespachoEstadoEntities { get; }
        IEtapaEstadoEntityRepository EtapaEstadoEntities { get; }
        IPronosticoEntityRepository PronosticoEntities { get; }
        IZonaEntityRepository ZonaEntities { get; }
        IEquipoTecnologiaEntityRepository EquipoTecnologiaEntities { get; }
        IEquipoConfiguracionEntityRepository EquipoConfiguracionEntities { get; }
        IEquipoEntityRepository EquipoEntities { get; }
        IDespachoDetalleEntityRepository DespachoDetalleEntities { get; }
        IDespachoEncabezadoEntityRepository DespachoEncabezadoEntities { get; }
        IEquipoScrapEntityRepository EquipoScrapEntities { get; }
        IVWMovimientoEquipoEntityRepository VWMovimientoEquipoEntities { get; }
        IOperarioEntityRepository OperarioEntities { get; }
        ITempDespachoCsvEntityRepository TempDespachoCsvEntities { get; }
        IApiUserEntityRepository ApiUserEntities { get; }
        IEtapaSecuenciaEntityRepository EtapaSecuenciaEntities { get; }
        ITempEquipoMovimientoCsvEntityRepository TempEquipoMovimientoCsvEntities { get; }
        void Save();
    }
}
