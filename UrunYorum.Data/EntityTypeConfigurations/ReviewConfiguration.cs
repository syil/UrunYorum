using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UrunYorum.Data.Engine.EntityTypeConfigurations
{
    internal class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            HasRequired(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .WillCascadeOnDelete(false);

            HasRequired(r => r.User)
               .WithMany()
               .HasForeignKey(r => r.UserId);
        }
    }
}
