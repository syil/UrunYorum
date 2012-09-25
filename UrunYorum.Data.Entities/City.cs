using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class City
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CityId { get; set; }

        public string Name { get; set; }
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual List<Town> Towns { get; set; }
    }
}
