﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 10-12-2021 02:28:29 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public partial class SPSeguimientoDespachoEntityResultDto
    {
        #region Constructors

        public SPSeguimientoDespachoEntityResultDto() {
        }

        public SPSeguimientoDespachoEntityResultDto(int id, System.DateTime fecha, string esn, string guia, string estadoDespacho, int? caja, int? pallet, string derivada, string estadoUtp, string estadoFuentePoder, string estadoControlRemoto, string estadoHdmi, string estadoRca, bool pintura, bool controlCalidad, bool procesoFinalizado) {

          this.Id = id;
          this.Fecha = fecha;
          this.Esn = esn;
          this.Guia = guia;
          this.EstadoDespacho = estadoDespacho;
          this.Caja = caja;
          this.Pallet = pallet;
          this.Derivada = derivada;
          this.EstadoUtp = estadoUtp;
          this.EstadoFuentePoder = estadoFuentePoder;
          this.EstadoControlRemoto = estadoControlRemoto;
          this.EstadoHdmi = estadoHdmi;
          this.EstadoRca = estadoRca;
          this.Pintura = pintura;
          this.ControlCalidad = controlCalidad;
          this.ProcesoFinalizado = procesoFinalizado;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public System.DateTime Fecha { get; set; }

        public string Esn { get; set; }

        public string Guia { get; set; }

        public string EstadoDespacho { get; set; }

        public int? Caja { get; set; }

        public int? Pallet { get; set; }

        public string Derivada { get; set; }

        public string EstadoUtp { get; set; }

        public string EstadoFuentePoder { get; set; }

        public string EstadoControlRemoto { get; set; }

        public string EstadoHdmi { get; set; }

        public string EstadoRca { get; set; }

        public bool Pintura { get; set; }

        public bool ControlCalidad { get; set; }

        public bool ProcesoFinalizado { get; set; }

        #endregion
    }

}
