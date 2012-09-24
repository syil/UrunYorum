using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class RouteMap
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RouteMapId { get; set; }

        public Guid ItemId { get; set; }
        public string ItemType { get; set; }
        public string Slug { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime InsertDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastRouteDate { get; set; }
    }
}
