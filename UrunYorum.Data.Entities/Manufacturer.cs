using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class Manufacturer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ManufacturerId { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string WebsiteURL { get; set; }
        public string LogoPath { get; set; }
        public bool IsActive { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime InsertDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }


        public virtual List<Product> Products { get; set; }
    }
}
