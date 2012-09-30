using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class Town
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TownId { get; set; }

        public string Name { get; set; }
        public Guid CityId { get; set; }

        public virtual City City { get; set; }
    }
}
