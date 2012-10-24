using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Engine.IRepositories;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Engine.Infrastructure;

namespace UrunYorum.Data.Engine.Repositories
{
    public class LoginRepository : EntityRepository<Login>, ILoginRepository
    {
        public LoginRepository(IDbContextFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
