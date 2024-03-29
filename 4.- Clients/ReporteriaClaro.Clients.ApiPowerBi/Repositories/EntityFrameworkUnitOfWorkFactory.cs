﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for EF Core model.
// Code is generated on: 03-12-2021 09:23:55 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using Microsoft.EntityFrameworkCore;
using ReporteriaClaro.Clients.ApiPowerBi.Repositories.Interfaces;

namespace ReporteriaClaro.Clients.ApiPowerBi.Repositories
{
    public partial class EntityFrameworkUnitOfWorkFactory : IUnitOfWorkFactory
    {
        protected DbContext context = null;

        public EntityFrameworkUnitOfWorkFactory(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        #region IUnitOfWorkFactory Members

        public virtual IUnitOfWork Create()
        {
            if (context == null)
                throw new InvalidOperationException("Context has not been initialized.");
            return new EntityFrameworkUnitOfWork(context);
        }
        #endregion
    }
}
