﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 03-12-2021 09:23:53 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace ReporteriaMovistar.Clients.ApiPowerBi.Models
{
    public partial class VWDetallePronosticoEquipoPowerBiEntity {

        public virtual string Periodo { get; set; }

        public virtual int? Pronostico { get; set; }

        public virtual string Tecnologia { get; set; }

        public virtual int CantidadDiagnostico { get; set; }

        public virtual int CantidadAceptados { get; set; }

        public virtual int CantidadRechazados { get; set; }

        public virtual int CantidadPendientes { get; set; }

        public virtual int CantidadScrap { get; set; }

        public virtual int CantidadRemozados { get; set; }

        public virtual int CantidadDespachados { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
