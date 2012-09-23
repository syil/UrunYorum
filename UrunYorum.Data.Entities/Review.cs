using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class Review
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReviewId { get; set; }

        public string Title { get; set; }
        public string ReviewText { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public int HelpfullVoteCount { get; set; }
        public int UnhelpfullVoteCount { get; set; }
        public string SenderIP { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime InsertDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }

        public virtual Product Product { get; set; }
        public User User { get; set; }
    }
}
