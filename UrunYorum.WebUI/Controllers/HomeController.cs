﻿using System;
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
        public ActionResult Index()
        {
            return View();
        }

    }
}
