using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UrunYorum.Data.Engine.EntityTypeConfigurations
{
    internal class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            HasRequired(c => c.Country)
               .WithMany(c => c.Cities)
               .HasForeignKey(c => c.CountryId);
        }
    }
}
