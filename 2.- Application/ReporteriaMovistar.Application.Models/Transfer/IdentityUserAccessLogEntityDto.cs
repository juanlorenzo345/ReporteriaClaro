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

    public partial class IdentityUserAccessLogEntityDto
    {
        #region Constructors

        public IdentityUserAccessLogEntityDto() {
        }

        public IdentityUserAccessLogEntityDto(long id, string userId, string ipAddress, System.DateTime accessAt, bool successfulLogin, string detail, IdentityUserEntityDto identityUserEntity) {

          this.Id = id;
          this.UserId = userId;
          this.IpAddress = ipAddress;
          this.AccessAt = accessAt;
          this.SuccessfulLogin = successfulLogin;
          this.Detail = detail;
          this.IdentityUserEntity = identityUserEntity;
        }

        #endregion

        #region Properties

        public long Id { get; set; }

        public string UserId { get; set; }

        public string IpAddress { get; set; }

        public System.DateTime AccessAt { get; set; }

        public bool SuccessfulLogin { get; set; }

        public string Detail { get; set; }

        #endregion

        #region Navigation Properties

        public IdentityUserEntityDto IdentityUserEntity { get; set; }

        #endregion
    }

}