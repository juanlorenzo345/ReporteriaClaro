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
    public partial class EquipoEntity {

        public virtual int Id { get; set; }

        public virtual decimal HeaderId { get; set; }

        public virtual DateTime Fecha { get; set; }

        public virtual string Esn { get; set; }

        public virtual string NumeroReferencia { get; set; }

        public virtual int? ModeloId { get; set; }

        public virtual int? ColorId { get; set; }

        public virtual string Tipo { get; set; }

        public virtual string Subtipo { get; set; }

        public virtual string Categoria { get; set; }

        public virtual string Subcategoria { get; set; }

        public virtual string Estado { get; set; }

        public virtual string Subestado { get; set; }

        public virtual int? FuentePoderEstadoId { get; set; }

        public virtual int? UtpEstadoId { get; set; }

        public virtual int? ControlRemotoEstadoId { get; set; }

        public virtual int? HdmiEstadoId { get; set; }

        public virtual int? RcaEstadoId { get; set; }

        public virtual bool Pintura { get; set; }

        public virtual string Derivada { get; set; }

        public virtual bool ProcesoFinalizado { get; set; }

        public virtual DateTime FechaCreacionRegistro { get; set; }

        public virtual string UsuarioCreacionRegistro { get; set; }

        public virtual DateTime? FechaModificacionRegistro { get; set; }

        public virtual string UsuarioModificacionRegistro { get; set; }

        public virtual DateTime? FechaEliminacionRegistro { get; set; }

        public virtual string UsuarioEliminacionRegistro { get; set; }

        public virtual bool Activo { get; set; }

        public virtual EquipoColorEntity EquipoColorEntity { get; set; }

        public virtual EquipoModeloEntity EquipoModeloEntity { get; set; }

        public virtual IList<EquipoMovimientoEntity> EquipoMovimientoEntities { get; set; }

        public virtual IList<DespachoDetalleEntity> DespachoDetalleEntities { get; set; }

        public virtual IList<EquipoScrapEntity> EquipoScrapEntities { get; set; }

        public virtual ComponenteEstadoEntity ComponenteEstadoEntity_FuentePoderEstadoId { get; set; }

        public virtual ComponenteEstadoEntity ComponenteEstadoEntity_UtpEstadoId { get; set; }

        public virtual ComponenteEstadoEntity ComponenteEstadoEntity_ControlRemotoEstadoId { get; set; }

        public virtual ComponenteEstadoEntity ComponenteEstadoEntity_HdmiEstadoId { get; set; }

        public virtual ComponenteEstadoEntity ComponenteEstadoEntity_RcaEstadoId { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}