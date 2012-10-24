using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using UrunYorum.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LoginId { get; set; }

        public UserProvider UserProvider { get; set; }
        public string ProfileURL { get; set; }
        public string AuthenticateKey { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? AuthenticateDate { get; set; }

        public virtual User User { get; set; }
    }
}
