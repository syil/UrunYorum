﻿using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using UrunYorum.Core.IoC;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Engine;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Engine.IRepositories;
using UrunYorum.Data.Engine.Repositories;

namespace UrunYorum
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            
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