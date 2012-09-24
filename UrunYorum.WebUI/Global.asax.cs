using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.IoC;
using System.Data.Entity;
using UrunYorum.Data.Engine;
using UrunYorum.Data.Engine.IRepositories;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Contractor;

namespace UrunYorum
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);

            routes.MapRoute(
                "ProductDetail",
                "product/{slug}",
                new { Controller = "Product", Action = "Details" }
            );

            routes.MapRoute(
                "CategoryProducts",
                "category/{slug}",
                new { Controller = "Product", Action = "ListByCategory" }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UrunYorumDataContext>());

            IUnityContainer container = CreateUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private IUnityContainer CreateUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IDbContextFactory, DbContextFactory>(new HttpContextLifetimeManager<IDbContextFactory>());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>());

            container.RegisterType<IProductRepository, ProductRepository>(new HttpContextLifetimeManager<IProductRepository>());
            container.RegisterType<IProductDataService, ProductDataService>(new HttpContextLifetimeManager<IProductRepository>());

            container.RegisterType<IUserRepository, UserRepository>(new HttpContextLifetimeManager<IUserRepository>());
            container.RegisterType<IUserDataService, UserDataService>(new HttpContextLifetimeManager<IUserRepository>());

            container.RegisterType<IManufacturerRepository, ManufacturerRepository>(new HttpContextLifetimeManager<IManufacturerRepository>());
            container.RegisterType<IManufacturerDataService, ManufacturerDataService>(new HttpContextLifetimeManager<IManufacturerRepository>());

            container.RegisterType<IRouteMapRepository, RouteMapRepository>(new HttpContextLifetimeManager<IRouteMapRepository>());
            container.RegisterType<IRouteMapDataService, RouteMapDataService>(new HttpContextLifetimeManager<IRouteMapRepository>());

            return container;
        }
    }
}