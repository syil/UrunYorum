using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class Rating
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RatingId { get; set; }

        public int RatingValue { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RatingDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
