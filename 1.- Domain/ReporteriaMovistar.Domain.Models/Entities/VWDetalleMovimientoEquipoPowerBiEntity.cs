﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: jue. 11 nov. 2021 9:55:43
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

namespace ReporteriaMovistar.Domain.Models.Entities
{
    public partial class VWDetalleMovimientoEquipoPowerBiEntity {

        public virtual int RecepcionId { get; set; }

        public virtual string MarcaEquipo { get; set; }

        public virtual string ModeloEquipo { get; set; }

        public virtual string ColorEquipo { get; set; }

        public virtual string TecnologiaEquipo { get; set; }

        public virtual DateTime FechaRecepcion { get; set; }

        public virtual DateTime? FechaMovimiento { get; set; }

        public virtual string EtapaOrigen { get; set; }

        public virtual string ZonaOrigen { get; set; }

        public virtual string EtapaDestino { get; set; }

        public virtual string ZonaDestino { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
