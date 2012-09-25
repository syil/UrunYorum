using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Entities;
using UrunYorum.Base.Exceptions;

namespace UrunYorum.Core
{
    public class BaseController : Controller
    {
        private RouteMapDataService routeMapDataService;

        public BaseController(RouteMapDataService routeMapDataService)
        {
            this.routeMapDataService = routeMapDataService;
        }

        protected Guid GetMappedId(string slug, Type entityType)
        {
            try
            {
                RouteMap routeMap = routeMapDataService.ResolveRoute(slug, entityType.FullName);

                return routeMap.ItemId;
            }
            catch
            {
                throw new RouteMapCannotResolvedException()
                {
                    RequestedSlug = slug,
                    RequestedType = entityType.FullName
                };
            }
        }
    }
}
