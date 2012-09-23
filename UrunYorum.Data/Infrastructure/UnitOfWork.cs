using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Engine;

namespace UrunYorum.Data.Engine.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory databaseFactory;
        private UrunYorumDataContext dataContext;

        public UnitOfWork(IDbContextFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected UrunYorumDataContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.CreateNew()); }
        }

        public void CommitChanges()
        {
            DataContext.SaveChanges();
        }
    }
}
