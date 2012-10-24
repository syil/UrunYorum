using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Diagnostics;

namespace UrunYorum.Data.Engine
{
    public class UrunYorumDbInitializer : DropCreateDatabaseIfModelChanges<UrunYorumDataContext>
    {
        protected override void Seed(UrunYorumDataContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE RouteMaps NOCHECK CONSTRAINT [FK_dbo.RouteMaps_dbo.Categories_ItemId]");
            context.Database.ExecuteSqlCommand("ALTER TABLE RouteMaps NOCHECK CONSTRAINT [FK_dbo.RouteMaps_dbo.Manufacturers_ItemId]");
            context.Database.ExecuteSqlCommand("ALTER TABLE RouteMaps NOCHECK CONSTRAINT [FK_dbo.RouteMaps_dbo.Products_ItemId]");
        }
    }
}
