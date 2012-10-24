using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Core;
using UrunYorum.Data.Contractor.IServices;
using Microsoft.Practices.Unity;

namespace UrunYorum.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        [Dependency]
        public IProductDataService ProductDataService { get; set; }
        
        public ViewResult Index()
        {
            return View(ProductDataService.All);
        }

        public ActionResult Details(string slug)
        {
            Product product = null;

            try
            {
                Guid productId = GetMappedId(slug, typeof(Product));
                product = ProductDataService.Get(productId);

                return View(product);
            }
            catch (Exception exc)
            {
                ViewData.ModelState.AddModelError("ModelErrors", exc.Message);

                return View();
            }
        }

        [ChildActionOnly]
        public PartialViewResult ListByCategory(Guid uid)
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _ListItem(Guid uid)
        {
            Product product = null;

            try
            {
                product = ProductDataService.Get(uid);
            }
            catch (Exception)
            {
                throw;
            }

            return PartialView(product);
        }
    }
}
