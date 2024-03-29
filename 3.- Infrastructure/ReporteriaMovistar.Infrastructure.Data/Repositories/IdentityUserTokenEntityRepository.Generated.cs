﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 10-12-2021 02:28:28 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using ReporteriaMovistar.Domain.Interfaces.Repositories;

namespace ReporteriaMovistar.Infrastructure.Data.Repositories
{
    public partial class IdentityUserTokenEntityRepository : EntityFrameworkRepository<ReporteriaMovistar.Domain.Models.Entities.IdentityUserTokenEntity>, IIdentityUserTokenEntityRepository
    {
        public IdentityUserTokenEntityRepository(ReporteriaMovistar.Infrastructure.Data.DataProviders.ReporteriaMovistarDbContext context)
            : base(context)
        {
        }

        public virtual ICollection<ReporteriaMovistar.Domain.Models.Entities.IdentityUserTokenEntity> GetAll()
        {
            return objectSet.ToList();
        }

        public virtual ReporteriaMovistar.Domain.Models.Entities.IdentityUserTokenEntity GetByKey(string _UserId, string _LoginProvider, string _Name)
        {
            return objectSet.SingleOrDefault(e => e.UserId == _UserId && e.LoginProvider == _LoginProvider && e.Name == _Name);
        }

        public new ReporteriaMovistar.Infrastructure.Data.DataProviders.ReporteriaMovistarDbContext Context 
        {
            get
            {
                return (ReporteriaMovistar.Infrastructure.Data.DataProviders.ReporteriaMovistarDbContext)base.Context;
            }
        }
    }
}
