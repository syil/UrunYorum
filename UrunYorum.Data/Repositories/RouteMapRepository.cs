using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Engine.IRepositories;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Core.Exceptions;

namespace UrunYorum.Data.Engine.Repositories
{
    public class RouteMapRepository : EntityRepository<RouteMap>, IRouteMapRepository
    {
        public RouteMapRepository(IDbContextFactory dbFactory)
            : base(dbFactory)
        {
            
        }

        public RouteMap ResolveRoute(string slug, string itemType)
        {
            RouteMap routeMap = Get(r => r.Slug == slug && r.ItemType == itemType);

            if (routeMap != null)
            {
                return routeMap;
            }
            else
            {
                throw new RouteMapCannotResolvedException()
                {
                    RequestedSlug = slug,
                    RequestedType = itemType
                };
            }
        }
    }
}
