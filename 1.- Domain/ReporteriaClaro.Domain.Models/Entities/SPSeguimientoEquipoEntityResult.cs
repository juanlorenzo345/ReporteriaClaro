﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 10-12-2021 02:28:27 PM
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

namespace ReporteriaClaro.Domain.Models.Entities
{
    public partial class SPSeguimientoEquipoEntityResult {

        public SPSeguimientoEquipoEntityResult()
        {
            OnCreated();
        }

        public virtual int Id { get; set; }

        public virtual DateTime FechaRecepcion { get; set; }

        public virtual string Esn { get; set; }

        public virtual string Marca { get; set; }

        public virtual string Modelo { get; set; }

        public virtual string Color { get; set; }

        public virtual string Tecnologia { get; set; }

        public virtual string Configuracion { get; set; }

        public virtual string DetalleConfiguracion { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
