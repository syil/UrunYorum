using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Engine.IRepositories;

namespace UrunYorum.Data.Engine.Repositories
{
    public class TownRepository : EntityRepository<Town>, ITownRepository
    {
        public TownRepository(IDbContextFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
