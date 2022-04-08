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

    public partial class DespachoEstadoEntityDto
    {
        #region Constructors

        public DespachoEstadoEntityDto() {
        }

        public DespachoEstadoEntityDto(int id, string nombre, int posicion, System.DateTime fechaCreacionRegistro, string usuarioCreacionRegistro, System.DateTime? fechaModificacionRegistro, string usuarioModificacionRegistro, System.DateTime? fechaEliminacionRegistro, string usuarioEliminacionRegistro, bool activo, List<DespachoEncabezadoEntityDto> despachoEncabezadoEntities) {

          this.Id = id;
          this.Nombre = nombre;
          this.Posicion = posicion;
          this.FechaCreacionRegistro = fechaCreacionRegistro;
          this.UsuarioCreacionRegistro = usuarioCreacionRegistro;
          this.FechaModificacionRegistro = fechaModificacionRegistro;
          this.UsuarioModificacionRegistro = usuarioModificacionRegistro;
          this.FechaEliminacionRegistro = fechaEliminacionRegistro;
          this.UsuarioEliminacionRegistro = usuarioEliminacionRegistro;
          this.Activo = activo;
          this.DespachoEncabezadoEntities = despachoEncabezadoEntities;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Posicion { get; set; }

        public System.DateTime FechaCreacionRegistro { get; set; }

        public string UsuarioCreacionRegistro { get; set; }

        public System.DateTime? FechaModificacionRegistro { get; set; }

        public string UsuarioModificacionRegistro { get; set; }

        public System.DateTime? FechaEliminacionRegistro { get; set; }

        public string UsuarioEliminacionRegistro { get; set; }

        public bool Activo { get; set; }

        #endregion

        #region Navigation Properties

        public List<DespachoEncabezadoEntityDto> DespachoEncabezadoEntities { get; set; }

        #endregion
    }

}
