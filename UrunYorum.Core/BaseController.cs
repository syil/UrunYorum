using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Entities;
using UrunYorum.Base.Exceptions;
using Microsoft.Practices.Unity;

namespace UrunYorum.Core
{
    public class BaseController : Controller
    {
        [Dependency]
        public IRouteMapDataService RouteMapDataService { get; set; }

        protected Guid GetMappedId(string slug, Type entityType)
        {
            try
            {
                RouteMap routeMap = RouteMapDataService.ResolveRoute(slug, entityType.FullName);

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
