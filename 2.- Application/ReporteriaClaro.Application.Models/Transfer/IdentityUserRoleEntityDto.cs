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

    public partial class IdentityUserRoleEntityDto
    {
        #region Constructors

        public IdentityUserRoleEntityDto() {
        }

        public IdentityUserRoleEntityDto(string userId, string roleId, System.DateTime? createdAt, string createdBy, System.DateTime? modifiedAt, string modifiedBy, System.DateTime? deactivatedAt, string deactivatedBy, IdentityRoleEntityDto identityRoleEntity, IdentityUserEntityDto identityUserEntity) {

          this.UserId = userId;
          this.RoleId = roleId;
          this.CreatedAt = createdAt;
          this.CreatedBy = createdBy;
          this.ModifiedAt = modifiedAt;
          this.ModifiedBy = modifiedBy;
          this.DeactivatedAt = deactivatedAt;
          this.DeactivatedBy = deactivatedBy;
          this.IdentityRoleEntity = identityRoleEntity;
          this.IdentityUserEntity = identityUserEntity;
        }

        #endregion

        #region Properties

        public string UserId { get; set; }

        public string RoleId { get; set; }

        public System.DateTime? CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime? ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public System.DateTime? DeactivatedAt { get; set; }

        public string DeactivatedBy { get; set; }

        #endregion

        #region Navigation Properties

        public IdentityRoleEntityDto IdentityRoleEntity { get; set; }

        public IdentityUserEntityDto IdentityUserEntity { get; set; }

        #endregion
    }

}
