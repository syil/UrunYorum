﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Engine.Infrastructure;
using System.Linq.Expressions;

namespace UrunYorum.Data.Contractor.Base
{
    public class EntityService<TIEntityRepository, TEntity>
        where TIEntityRepository : IRepositoryBase<TEntity>
        where TEntity : class
    {
        private TIEntityRepository repository;
        private IUnitOfWork unitOfWork;

        public EntityService(TIEntityRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public EntityService()
        {

        }

        public IEnumerable<TEntity> All
        {
            get { return repository.All; }
        }

        public virtual void Insert(TEntity entity)
        {
            repository.Insert(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return repository.GetMany(where);
        }
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return repository.Get(where);
        }


        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return repository.AllIncluding(includeProperties);
        }

        public TEntity Find(Guid id)
        {
            return repository.Find(id);
        }

        public void Update(TEntity entity)
        {
            // Existing entity
            repository.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = repository.Find(id);
            repository.Delete(entity);
        }

        public void Save()
        {
            unitOfWork.CommitChanges();
        }
    }
}
