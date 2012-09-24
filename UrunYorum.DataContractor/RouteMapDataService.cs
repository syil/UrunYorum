using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Engine.IRepositories;
using UrunYorum.Data.Contractor.Base;
using UrunYorum.Data.Engine.Infrastructure;

namespace UrunYorum.Data.Contractor
{
    public class RouteMapDataService : EntityService<IRouteMapRepository, RouteMap>, IRouteMapDataService
    {
        public RouteMapDataService(IRouteMapRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {

        }

        public RouteMap ResolveRoute(string slug, string itemType)
        {
            RouteMap routeMap = repository.ResolveRoute(slug, itemType);
            routeMap.LastRouteDate = DateTime.Now;

            Update(routeMap);
            Save();

            return routeMap;
        }
    }
}
