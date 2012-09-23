using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Engine.Infrastructure;

namespace UrunYorum.Test.DatabaseObjectTests
{
    public abstract class DboTestBase
    {
        protected DbContextFactory DbContextFactory { get; private set; }
        protected UnitOfWork UnitOfWork { get; private set; }

        protected DboTestBase()
        {
            DbContextFactory = new DbContextFactory();
            UnitOfWork = new UnitOfWork(DbContextFactory);
        }
    }
}
