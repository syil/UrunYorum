using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UrunYorum.Data.Engine.Infrastructure;
using System.Data;
using System.Linq.Expressions;

namespace UrunYorum.Data.Engine.Infrastructure
{
    public class EntityRepository<TEntity> : RepositoryBase where TEntity : class
    {
        private IDbSet<TEntity> dbset;

        public IEnumerable<TEntity> All
        {
            get { return dbset.ToList(); }
        }

        public EntityRepository(IDbContextFactory dbFactory)
            : base(dbFactory)
        {
            dbset = DataContext.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return dbset.Where(where).ToList();
        }
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return dbset.Where(where).FirstOrDefault<TEntity>();
        }


        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbset;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TEntity Find(Guid id)
        {
            return dbset.Find(id);
        }

        public void Update(TEntity entity)
        {
            // Existing entity
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var entity = dbset.Find(id);
            dbset.Remove(entity);
        }
    }
}
