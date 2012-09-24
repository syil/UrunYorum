using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;

namespace UrunYorum.Controllers
{
    public class ProductController : Controller
    {
        private ProductDataService productsDataService;

        public ProductController(ProductDataService productsDataService)
	    {
            this.productsDataService = productsDataService;
        }

        public ViewResult Index()
        {
            return View(productsDataService.All);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            productsDataService.Insert(product);
            productsDataService.Save();

            return View();
        }

        public ActionResult Details(string slug)
        {
            ViewBag.slug = slug;

            return View(new Product());
        }
    }
}
