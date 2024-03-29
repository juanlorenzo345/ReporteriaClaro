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
    public partial class IdentityUserLoginEntity {

        public virtual string LoginProvider { get; set; }

        public virtual string ProviderKey { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? ModifiedAt { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? DeactivatedAt { get; set; }

        public virtual string DeactivatedBy { get; set; }

        public virtual string ProviderDisplayName { get; set; }

        public virtual string UserId { get; set; }

        public virtual IdentityUserEntity IdentityUserEntity { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        public override bool Equals(object obj)
        {
          IdentityUserLoginEntity toCompare = obj as IdentityUserLoginEntity;
          if (toCompare == null)
          {
            return false;
          }

          if (!Object.Equals(this.LoginProvider, toCompare.LoginProvider))
            return false;
          if (!Object.Equals(this.ProviderKey, toCompare.ProviderKey))
            return false;

          return true;
        }

        public override int GetHashCode()
        {
          int hashCode = 13;
          hashCode = (hashCode * 7) + LoginProvider.GetHashCode();
          hashCode = (hashCode * 7) + ProviderKey.GetHashCode();
          return hashCode;
        }

        #endregion
    }

}
