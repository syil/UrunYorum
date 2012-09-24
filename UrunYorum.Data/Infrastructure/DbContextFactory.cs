using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Core.Base;

namespace UrunYorum.Data.Engine.Infrastructure
{
    public class DbContextFactory : Disposable, IDbContextFactory
    {
        private UrunYorumDataContext _dbContext;
        public UrunYorumDataContext CreateNew()
        {
            return _dbContext ?? (_dbContext = new UrunYorumDataContext());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
