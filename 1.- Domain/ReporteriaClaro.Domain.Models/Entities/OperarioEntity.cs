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
    public partial class OperarioEntity {

        public virtual int Id { get; set; }

        public virtual string Nombre { get; set; }

        public virtual DateTime FechaCreacionRegistro { get; set; }

        public virtual string UsuarioCreacionRegistro { get; set; }

        public virtual DateTime? FechaModificacionRegistro { get; set; }

        public virtual string UsuarioModificacionRegistro { get; set; }

        public virtual DateTime? FechaEliminacionRegistro { get; set; }

        public virtual string UsuarioEliminacionRegistro { get; set; }

        public virtual bool Activo { get; set; }

        public virtual IList<EquipoMovimientoEntity> EquipoMovimientoEntities_OperarioId { get; set; }

        public virtual IList<EquipoMovimientoEntity> EquipoMovimientoEntities_OperarioDevolucionId { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
