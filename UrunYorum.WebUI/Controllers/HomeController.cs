using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Core;
using UrunYorum.Data.Contractor;

namespace UrunYorum.Controllers
{
    public class HomeController : BaseController
    {
        private ProductRepository productsRepository;

        public HomeController(ProductRepository productsRepository, RouteMapDataService routeMapDataService)
            : base(routeMapDataService)
        {
            this.productsRepository = productsRepository;
        }

        public ActionResult Index()
        {
            productsRepository.All.FirstOrDefault();

            return View();
        }

    }
}
