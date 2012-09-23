using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Engine.IRepositories;
using UrunYorum.Data.Entities;

namespace UrunYorum.Data.Engine.Repositories
{
    public class ManufacturerRepository : EntityRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(IDbContextFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
