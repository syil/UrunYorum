using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Engine.Infrastructure;

namespace UrunYorum.Data.Engine.IRepositories
{
    public interface IRouteMapRepository : IRepositoryBase<RouteMap>
    {
        RouteMap ResolveRoute(string slug, string itemType);
    }
}
