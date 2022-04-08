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

namespace ReporteriaClaro.Application.Models.Transfer
{

    public partial class ZonaEntityDto
    {
        #region Constructors

        public ZonaEntityDto() {
        }

        public ZonaEntityDto(int id, string nombre, System.DateTime fechaCreacionRegistro, string usuarioCreacionRegistro, System.DateTime? fechaModificacionRegistro, string usuarioModificacionRegistro, System.DateTime? fechaEliminacionRegistro, string usuarioEliminacionRegistro, bool activo, List<EtapaEntityDto> etapaEntities) {

          this.Id = id;
          this.Nombre = nombre;
          this.FechaCreacionRegistro = fechaCreacionRegistro;
          this.UsuarioCreacionRegistro = usuarioCreacionRegistro;
          this.FechaModificacionRegistro = fechaModificacionRegistro;
          this.UsuarioModificacionRegistro = usuarioModificacionRegistro;
          this.FechaEliminacionRegistro = fechaEliminacionRegistro;
          this.UsuarioEliminacionRegistro = usuarioEliminacionRegistro;
          this.Activo = activo;
          this.EtapaEntities = etapaEntities;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Nombre { get; set; }

        public System.DateTime FechaCreacionRegistro { get; set; }

        public string UsuarioCreacionRegistro { get; set; }

        public System.DateTime? FechaModificacionRegistro { get; set; }

        public string UsuarioModificacionRegistro { get; set; }

        public System.DateTime? FechaEliminacionRegistro { get; set; }

        public string UsuarioEliminacionRegistro { get; set; }

        public bool Activo { get; set; }

        #endregion

        #region Navigation Properties

        public List<EtapaEntityDto> EtapaEntities { get; set; }

        #endregion
    }

}
