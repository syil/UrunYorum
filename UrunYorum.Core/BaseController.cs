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
using UrunYorum.Base.Interfaces;
using System.Web.Routing;
using UrunYorum.Core.Membership;

namespace UrunYorum.Core
{
    public class BaseController : Controller
    {
        [Dependency]
        public IRouteMapDataService RouteMapDataService { get; set; }
        [Dependency]
        public ILoginDataService LoginDataService { get; set; }
        [Dependency]
        public IAuthenticationService AuthenticationService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            ViewBag.CurrentUser = CurrentUser;
            
            base.OnAuthorization(filterContext);
        }

        public BaseController()
        {
            
        }

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

        public User CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    string userKey = User.Identity.Name;
                    Login loginInfo = LoginDataService.Find(l => l.AuthenticateKey == userKey);

                    if (loginInfo != null)
                    {
                        return loginInfo.User;
                    }
                }

                return null;
            }
        }
    }
}
