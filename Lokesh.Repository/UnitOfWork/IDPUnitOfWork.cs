﻿using Lokesh.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lokesh.Repository.UnitOfWork
{
    public interface IDPUnitOfWork : IUnitOfWork
    {
        IEnumerable<TEntity> CreateSet<TEntity>() where TEntity : class;
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
    }
}
