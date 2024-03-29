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

    public partial class EtapaSecuenciaEntityDto
    {
        #region Constructors

        public EtapaSecuenciaEntityDto() {
        }

        public EtapaSecuenciaEntityDto(int id, int etapaId, int etapaAnteriorPosteriorId, bool esEtapaAnterior, System.DateTime fechaCreacionRegistro, string usuarioCreacionRegistro, System.DateTime? fechaModificacionRegistro, string usuarioModificacionRegistro, System.DateTime? fechaEliminacionRegistro, string usuarioEliminacionRegistro, bool activo, EtapaEntityDto etapaEntity_EtapaId, EtapaEntityDto etapaEntity_EtapaAnteriorPosteriorId) {

          this.Id = id;
          this.EtapaId = etapaId;
          this.EtapaAnteriorPosteriorId = etapaAnteriorPosteriorId;
          this.EsEtapaAnterior = esEtapaAnterior;
          this.FechaCreacionRegistro = fechaCreacionRegistro;
          this.UsuarioCreacionRegistro = usuarioCreacionRegistro;
          this.FechaModificacionRegistro = fechaModificacionRegistro;
          this.UsuarioModificacionRegistro = usuarioModificacionRegistro;
          this.FechaEliminacionRegistro = fechaEliminacionRegistro;
          this.UsuarioEliminacionRegistro = usuarioEliminacionRegistro;
          this.Activo = activo;
          this.EtapaEntity_EtapaId = etapaEntity_EtapaId;
          this.EtapaEntity_EtapaAnteriorPosteriorId = etapaEntity_EtapaAnteriorPosteriorId;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public int EtapaId { get; set; }

        public int EtapaAnteriorPosteriorId { get; set; }

        public bool EsEtapaAnterior { get; set; }

        public System.DateTime FechaCreacionRegistro { get; set; }

        public string UsuarioCreacionRegistro { get; set; }

        public System.DateTime? FechaModificacionRegistro { get; set; }

        public string UsuarioModificacionRegistro { get; set; }

        public System.DateTime? FechaEliminacionRegistro { get; set; }

        public string UsuarioEliminacionRegistro { get; set; }

        public bool Activo { get; set; }

        #endregion

        #region Navigation Properties

        public EtapaEntityDto EtapaEntity_EtapaId { get; set; }

        public EtapaEntityDto EtapaEntity_EtapaAnteriorPosteriorId { get; set; }

        #endregion
    }

}
