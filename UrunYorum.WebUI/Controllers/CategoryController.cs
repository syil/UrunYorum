using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYorum.Data.Contractor;
using UrunYorum.Core;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Contractor.IServices;
using Microsoft.Practices.Unity;

namespace UrunYorum.WebUI.Controllers
{
    public class CategoryController : BaseController
    {
        [Dependency]
        public ICategoryDataService CategoryDataService { get; set; }

        [ChildActionOnly, OutputCache(Duration = 604800)]
        public PartialViewResult CategoryMenu()
        {
            List<Category> categories = CategoryDataService.FindMany(c => c.IsActive && c.ParentCategory == null).ToList();

            return PartialView(categories);
        }

        public ActionResult Details(string slug)
        {
            Category category = null;
            try
            {
                category = CategoryDataService.Find(c => c.RouteMapInfo.Slug == slug);
            }
            catch (Exception)
            {

            }

            return View(category);
        }
    }
}
