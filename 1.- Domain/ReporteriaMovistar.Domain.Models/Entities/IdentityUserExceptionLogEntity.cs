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
    public partial class IdentityUserExceptionLogEntity {

        public virtual int Id { get; set; }

        public virtual string UserId { get; set; }

        public virtual string Message { get; set; }

        public virtual string Type { get; set; }

        public virtual string Source { get; set; }

        public virtual string Url { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual IdentityUserEntity IdentityUserEntity { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
