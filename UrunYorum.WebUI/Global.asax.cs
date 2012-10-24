using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using UrunYorum.Core;
using UrunYorum.Core.IoC;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Engine;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Engine.IRepositories;
using UrunYorum.Data.Engine.Repositories;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using UrunYorum.Core.Membership;
using UrunYorum.Base.Interfaces;

namespace UrunYorum
{
    public class MvcApplication : HttpApplication
    {
        private static IUnityContainer container;

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
            //RegisterRoutes(RouteTable.Routes);
            

            InitContainer();
            //ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private void InitContainer()
        {
            if (container == null)
            {
                container = new UnityContainer();
            }

            container.RegisterType<IDbContextFactory, DbContextFactory>(new HttpContextLifetimeManager<IDbContextFactory>());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>());

            container.RegisterType<IProductRepository, ProductRepository>(new HttpContextLifetimeManager<IProductRepository>());
            container.RegisterType<IProductDataService, ProductDataService>(new HttpContextLifetimeManager<IProductRepository>());

            container.RegisterType<IUserRepository, UserRepository>(new HttpContextLifetimeManager<IUserRepository>());
            container.RegisterType<IUserDataService, UserDataService>(new HttpContextLifetimeManager<IUserRepository>());

            container.RegisterType<ILoginRepository, LoginRepository>(new HttpContextLifetimeManager<ILoginRepository>());
            container.RegisterType<ILoginDataService, LoginDataService>(new HttpContextLifetimeManager<ILoginRepository>());

            container.RegisterType<IManufacturerRepository, ManufacturerRepository>(new HttpContextLifetimeManager<IManufacturerRepository>());
            container.RegisterType<IManufacturerDataService, ManufacturerDataService>(new HttpContextLifetimeManager<IManufacturerRepository>());

            container.RegisterType<ICategoryRepository, CategoryRepository>(new HttpContextLifetimeManager<ICategoryRepository>());
            container.RegisterType<ICategoryDataService, CategoryDataService>(new HttpContextLifetimeManager<ICategoryRepository>());

            container.RegisterType<IRouteMapRepository, RouteMapRepository>(new HttpContextLifetimeManager<IRouteMapRepository>());
            container.RegisterType<IRouteMapDataService, RouteMapDataService>(new HttpContextLifetimeManager<IRouteMapRepository>());

            container.RegisterType<IReviewRepository, ReviewRepository>(new HttpContextLifetimeManager<IReviewRepository>());
            container.RegisterType<IReviewDataService, ReviewDataService>(new HttpContextLifetimeManager<IReviewRepository>());

            container.RegisterType<IAuthenticationService, FormsAuthenticationService>(new HttpContextLifetimeManager<IAuthenticationService>());
        }
    }
}