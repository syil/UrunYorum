using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrunYorum.Data.Entities
{
    public class ProductPicture
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductPictureId { get; set; }

        public string PicturePath { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDefaultPicture { get; set; }
        public Guid AddedById { get; set; }
        public Guid ProductId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime InsertDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual User AddedBy { get; set; }
    }
}
