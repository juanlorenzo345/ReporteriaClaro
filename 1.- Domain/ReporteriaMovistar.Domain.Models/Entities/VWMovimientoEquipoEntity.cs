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
    public partial class VWMovimientoEquipoEntity {

        public virtual int Id { get; set; }

        public virtual DateTime Fecha { get; set; }

        public virtual string Esn { get; set; }

        public virtual string Marca { get; set; }

        public virtual string Modelo { get; set; }

        public virtual string Color { get; set; }

        public virtual int OrigenId { get; set; }

        public virtual string Origen { get; set; }

        public virtual int DestinoId { get; set; }

        public virtual string Destino { get; set; }

        public virtual string Operario { get; set; }

        public virtual string OperarioDevolucion { get; set; }

        public virtual string Observacion { get; set; }

        public virtual DateTime FechaCreacionRegistro { get; set; }

        public virtual string UsuarioCreacionRegistro { get; set; }

        public virtual DateTime? FechaModificacionRegistro { get; set; }

        public virtual string UsuarioModificacionRegistro { get; set; }

        public virtual DateTime? FechaEliminacionRegistro { get; set; }

        public virtual string UsuarioEliminacionRegistro { get; set; }

        public virtual bool Activo { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
