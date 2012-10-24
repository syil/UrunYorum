using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.Unity;
using UrunYorum.Core;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Entities;

namespace UrunYorum.WebUI.Controllers
{
    public class CategoryController : BaseController
    {
        [Dependency]
        public ICategoryDataService CategoryDataService { get; set; }

        [ChildActionOnly, OutputCache(Duration = 604800)]
        public PartialViewResult _CategoryMenu()
        {
            List<Category> categories = null;
            try
            {
                categories = CategoryDataService.FindMany(c => c.IsActive && c.ParentCategory == null).ToList();
            }
            catch (Exception exc)
            {
                bool rethrow = ExceptionPolicy.HandleException(exc, SystemConstants.ExceptionLogPolicyName);
                if (rethrow)
                    throw;
            }

            return PartialView(categories);
        }

        public ActionResult Details(string slug)
        {
            Category category = null;
            try
            {
                category = CategoryDataService.Find(c => c.RouteMapInfo.Slug == slug);
            }
            catch (Exception exc)
            {
                bool rethrow = ExceptionPolicy.HandleException(exc, SystemConstants.ExceptionLogPolicyName);
                if (rethrow)
                    throw;
            }

            return View(category);
        }
    }
}
