using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CountryId { get; set; }

        public string Name { get; set; }
        public string LanguageCode { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
