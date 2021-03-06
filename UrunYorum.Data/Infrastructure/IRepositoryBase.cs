﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace UrunYorum.Data.Engine.Infrastructure
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> FindMany(Func<TEntity, bool> where);
        IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Get(Guid id);
        TEntity Find(Func<TEntity, Boolean> where);

        void Insert(TEntity entity);
        void Update(TEntity products);
        void Delete(Guid id);
        void Delete(TEntity entity);

        IEnumerable<TEntity> All { get; }
    }
}
