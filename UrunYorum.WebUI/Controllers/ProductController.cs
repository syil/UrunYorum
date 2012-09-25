using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Core;

namespace UrunYorum.Controllers
{
    public class ProductController : BaseController
    {
        private ProductDataService productDataService;

        public ProductController(ProductDataService productsDataService, RouteMapDataService routeMapDataService)
            : base(routeMapDataService)
	    {
            this.productDataService = productsDataService;
        }

        public ViewResult Index()
        {
            return View(productDataService.All);
        }

        public ActionResult Details(string slug)
        {
            Product product = null;

            try
            {
                Guid productId = GetMappedId(slug, typeof(Product));
                product = productDataService.Find(productId);
            }
            catch (Exception exc)
            {
                ViewData.ModelState.AddModelError("ModelErrors", exc.Message);
            }

            return View(product);
        }

        public ActionResult ListByCategory(string slug)
        {
            ViewBag.slug = slug;

            return View(productDataService.All);
        }
    }
}
