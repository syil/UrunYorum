using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Entities;
using UrunYorum.Core;

namespace UrunYorum.WebUI.Controllers
{
    public class ReviewController : BaseController
    {
        [Dependency]
        public IReviewDataService ReviewDataService { get; set; }

        [ChildActionOnly]
        public PartialViewResult Single()
        {
            return PartialView();
        }

        public ActionResult ReadMore(string productSlug, int reviewIndex)
        {
            Review review = null;

            try
            {
                Guid productId = GetMappedId(productSlug, typeof(Product));
                var reviews = ReviewDataService.FindMany(r => r.ProductId == productId);
                reviews = reviews.OrderByDescending(r => r.InsertDate);
                review = reviews.ElementAtOrDefault(reviewIndex - 1);

                return View(review);
            }
            catch (Exception exc)
            {
                ViewData.ModelState.AddModelError("ModelErrors", exc.Message);

                return View();
            }
        }
    }
}
