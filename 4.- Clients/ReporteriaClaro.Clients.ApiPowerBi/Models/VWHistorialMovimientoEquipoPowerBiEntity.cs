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

namespace ReporteriaClaro.Clients.ApiPowerBi.Models
{
    public partial class VWHistorialMovimientoEquipoPowerBiEntity {

        public virtual string Esn { get; set; }

        public virtual DateTime FechaRecepcion { get; set; }

        public virtual string Marca { get; set; }

        public virtual string Modelo { get; set; }

        public virtual string Color { get; set; }

        public virtual string Tipo { get; set; }

        public virtual string Subtipo { get; set; }

        public virtual string NumeroReferencia { get; set; }

        public virtual string Categoria { get; set; }

        public virtual string Subcategoria { get; set; }

        public virtual string Operario { get; set; }

        public virtual string Origen { get; set; }

        public virtual string Destino { get; set; }

        public virtual string Observacion { get; set; }

        public virtual int? Caja { get; set; }

        public virtual int? Pallet { get; set; }

        public virtual string TipoConfiguracion { get; set; }

        public virtual string DetalleTipoConfiguracion { get; set; }

        public virtual string Tecnologia { get; set; }

        public virtual string ProcesoFinalizado { get; set; }

        public virtual string Derivada { get; set; }

        public virtual string Guia { get; set; }

        public virtual DateTime Fecha { get; set; }

        public virtual string Pintura { get; set; }

        public virtual string ControlRemoto { get; set; }

        public virtual string FuentePoder { get; set; }

        public virtual string Hdmi { get; set; }

        public virtual string Rca { get; set; }

        public virtual string Utp { get; set; }

        public virtual string EstadoDespacho { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
