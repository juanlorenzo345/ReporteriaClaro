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

namespace ReporteriaMovistar.Domain.Models.Entities
{
    public partial class TempEquipoMovimientoCsvEntity {

        public virtual int Id { get; set; }

        public virtual DateTime Fecha { get; set; }

        public virtual string Esn { get; set; }

        public virtual string Operario { get; set; }

        public virtual string OperarioDevolucion { get; set; }

        public virtual string Observacion { get; set; }

        public virtual int? EquipoId { get; set; }

        public virtual int? OperarioId { get; set; }

        public virtual int? OperarioDevolucionId { get; set; }

        public virtual DateTime FechaCreacionRegistro { get; set; }

        public virtual string UsuarioCreacionRegistro { get; set; }

        public virtual bool CargaExitosa { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}