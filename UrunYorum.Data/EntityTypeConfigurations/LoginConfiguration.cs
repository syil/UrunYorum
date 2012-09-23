using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using UrunYorum.Data.Entities;

namespace UrunYorum.Data.Engine.EntityTypeConfigurations
{
    internal class LoginConfiguration : EntityTypeConfiguration<Login>
    {
        public LoginConfiguration()
        {
            HasRequired(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId);
        }
    }
}
