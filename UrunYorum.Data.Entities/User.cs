using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        public string Name { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? TownId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastSeenDate { get; set; }

        public virtual Login LoginInfo { get; set; }
        public virtual City City { get; set; }
        public virtual Town Town { get; set; }
        public virtual Country Country { get; set; }
    }
}
