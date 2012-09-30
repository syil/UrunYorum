using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public virtual RouteMap RouteMapInfo { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual List<Category> SubCategories { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
