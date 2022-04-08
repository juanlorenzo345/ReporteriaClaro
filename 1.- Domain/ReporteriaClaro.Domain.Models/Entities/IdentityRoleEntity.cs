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
    public partial class IdentityRoleEntity {

        public virtual string Id { get; set; }

        public virtual bool AvailableAsAdmin { get; set; }

        public virtual bool AvailableAsSuperAdmin { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? ModifiedAt { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? DeactivatedAt { get; set; }

        public virtual string DeactivatedBy { get; set; }

        public virtual string Name { get; set; }

        public virtual string NormalizedName { get; set; }

        public virtual string ConcurrencyStamp { get; set; }

        public virtual IList<IdentityRoleClaimEntity> IdentityRoleClaimEntities { get; set; }

        public virtual IList<IdentityUserRoleEntity> IdentityUserRoleEntities { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
