﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYorum.Data.Engine.Repositories;

namespace UrunYorum.Controllers
{
    public class HomeController : Controller
    {
        private ProductRepository productsRepository;

        public HomeController(ProductRepository productsRepository)
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