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
    public partial class IdentityUserRoleEntity {

        public virtual string UserId { get; set; }

        public virtual string RoleId { get; set; }

        public virtual DateTime? CreatedAt { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? ModifiedAt { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? DeactivatedAt { get; set; }

        public virtual string DeactivatedBy { get; set; }

        public virtual IdentityRoleEntity IdentityRoleEntity { get; set; }

        public virtual IdentityUserEntity IdentityUserEntity { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        public override bool Equals(object obj)
        {
          IdentityUserRoleEntity toCompare = obj as IdentityUserRoleEntity;
          if (toCompare == null)
          {
            return false;
          }

          if (!Object.Equals(this.UserId, toCompare.UserId))
            return false;
          if (!Object.Equals(this.RoleId, toCompare.RoleId))
            return false;

          return true;
        }

        public override int GetHashCode()
        {
          int hashCode = 13;
          hashCode = (hashCode * 7) + UserId.GetHashCode();
          hashCode = (hashCode * 7) + RoleId.GetHashCode();
          return hashCode;
        }

        #endregion
    }

}
