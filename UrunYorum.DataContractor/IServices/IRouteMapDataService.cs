using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;

namespace UrunYorum.Data.Contractor.IServices
{
    public interface IRouteMapDataService : Base.IDataServiceBase<RouteMap>
    {
        RouteMap ResolveRoute(string slug, string itemType);
    }
}
