﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Engine.IRepositories;

namespace UrunYorum.Data.Engine.Repositories
{
    public class ReviewRepository : EntityRepository<Review>, IReviewRepository
    {
        public ReviewRepository(IDbContextFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
