﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: jue. 11 nov. 2021 9:55:43
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public partial class VWDetalleMovimientoEquipoPowerBiEntityDto
    {
        #region Constructors

        public VWDetalleMovimientoEquipoPowerBiEntityDto() {
        }

        public VWDetalleMovimientoEquipoPowerBiEntityDto(int recepcionId, string marcaEquipo, string modeloEquipo, string colorEquipo, string tecnologiaEquipo, System.DateTime fechaRecepcion, System.DateTime? fechaMovimiento, string etapaOrigen, string zonaOrigen, string etapaDestino, string zonaDestino) {

          this.RecepcionId = recepcionId;
          this.MarcaEquipo = marcaEquipo;
          this.ModeloEquipo = modeloEquipo;
          this.ColorEquipo = colorEquipo;
          this.TecnologiaEquipo = tecnologiaEquipo;
          this.FechaRecepcion = fechaRecepcion;
          this.FechaMovimiento = fechaMovimiento;
          this.EtapaOrigen = etapaOrigen;
          this.ZonaOrigen = zonaOrigen;
          this.EtapaDestino = etapaDestino;
          this.ZonaDestino = zonaDestino;
        }

        #endregion

        #region Properties

        public int RecepcionId { get; set; }

        public string MarcaEquipo { get; set; }

        public string ModeloEquipo { get; set; }

        public string ColorEquipo { get; set; }

        public string TecnologiaEquipo { get; set; }

        public System.DateTime FechaRecepcion { get; set; }

        public System.DateTime? FechaMovimiento { get; set; }

        public string EtapaOrigen { get; set; }

        public string ZonaOrigen { get; set; }

        public string EtapaDestino { get; set; }

        public string ZonaDestino { get; set; }

        #endregion
    }

}
