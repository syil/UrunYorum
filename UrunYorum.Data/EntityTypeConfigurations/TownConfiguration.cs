using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UrunYorum.Data.Engine.EntityTypeConfigurations
{
    internal class TownConfiguration : EntityTypeConfiguration<Town>
    {
        public TownConfiguration()
        {
            HasRequired(t => t.City)
               .WithMany(c => c.Towns)
               .HasForeignKey(t => t.CityId);
        }
    }
}
