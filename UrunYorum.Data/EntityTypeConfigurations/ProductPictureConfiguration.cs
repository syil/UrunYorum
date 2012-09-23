using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UrunYorum.Data.Engine.EntityTypeConfigurations
{
    internal class ProductPictureConfiguration : EntityTypeConfiguration<ProductPicture>
    {
        public ProductPictureConfiguration()
        {
            HasRequired(p => p.AddedBy)
                .WithMany()
                .HasForeignKey(p => p.AddedById)
                .WillCascadeOnDelete(false);

            HasRequired(pp => pp.Product)
                .WithMany(p => p.ProductPictures)
                .HasForeignKey(pp => pp.ProductId);
        }
    }
}
