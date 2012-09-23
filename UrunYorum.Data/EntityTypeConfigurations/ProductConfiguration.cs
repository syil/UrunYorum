using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UrunYorum.Data.Engine.EntityTypeConfigurations
{
    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(m =>
                {
                    m.MapLeftKey("ProductId");
                    m.MapRightKey("CategoryId");
                    m.ToTable("ProductCategoryMap");
                });

            HasRequired(p => p.Manufacturer)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.ManufacturerId);

            HasRequired(p => p.AddedBy)
                .WithMany()
                .HasForeignKey(p => p.AddedById);
        }
    }
}
