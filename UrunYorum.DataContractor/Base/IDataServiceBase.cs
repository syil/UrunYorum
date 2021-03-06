﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace UrunYorum.Data.Contractor.Base
{
    public interface IDataServiceBase<TEntity>
        where TEntity : class, new()
    {
        IEnumerable<TEntity> FindMany(Func<TEntity, bool> where);
        IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Get(Guid id);
        TEntity Find(Func<TEntity, bool> where);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
        void Save();

        IEnumerable<TEntity> All { get; }
    }
}
