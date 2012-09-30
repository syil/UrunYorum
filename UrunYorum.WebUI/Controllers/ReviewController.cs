using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Entities;

namespace UrunYorum.Controllers
{
    public class ReviewController : Controller
    {
        [Dependency]
        public IReviewDataService ReviewDataService { get; set; }

        [ChildActionOnly]
        public PartialViewResult Single()
        {
            return PartialView();
        }
    }
}
