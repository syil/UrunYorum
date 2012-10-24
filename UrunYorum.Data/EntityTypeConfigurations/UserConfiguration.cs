using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UrunYorum.Data.Engine.EntityTypeConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasOptional(u => u.LoginInfo)
                .WithOptionalPrincipal(l => l.User)
                .Map(m =>
                {
                    m.MapKey("UserId");
                });
        }
    }
}
