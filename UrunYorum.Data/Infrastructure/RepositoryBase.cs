using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Engine;
using UrunYorum.Data.Engine.Infrastructure;

namespace UrunYorum.Data.Engine.Infrastructure
{
    public abstract class RepositoryBase
    {
        private UrunYorumDataContext dataContext;
        protected RepositoryBase(IDbContextFactory IDbFactory)
        {
            DatabaseFactory = IDbFactory;
        }
        protected IDbContextFactory DatabaseFactory
        {
            get;
            private set;
        }
        protected UrunYorumDataContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.CreateNew()); }
        }
    }
}
