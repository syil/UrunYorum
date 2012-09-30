using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunYorum.Data.Entities;

namespace UrunYorum.ViewModels
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<Review> TopReviews { get; set; }

    }
}