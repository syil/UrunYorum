using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }
        public bool IsApporoved { get; set; }
        public bool IsDeleted { get; set; }
        public int ManufacturingYear { get; set; }
        public string ShortDescription { get; set; }
        public string MetaKeywords { get; set; }
        public double? SumRating { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid AddedById { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string FullDescription { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime InsertDate { get; set; }

        public virtual User AddedBy { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual List<ProductPicture> ProductPictures { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
