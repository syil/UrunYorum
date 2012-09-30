using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UrunYorum.Data.Entities;
using UrunYorum.Core;
using UrunYorum.Data.Engine.EntityTypeConfigurations;

namespace UrunYorum.Data.Engine
{
    public class UrunYorumDataContext : DbContext
    {
        public UrunYorumDataContext()
            : base(SystemConstants.ConnectionStringName)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<RouteMap> RouteMaps { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductPictureConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
            modelBuilder.Configurations.Add(new ReviewConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new LoginConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new TownConfiguration());
            modelBuilder.Configurations.Add(new RouteMapConfiguration());
            modelBuilder.Configurations.Add(new ManufacturerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
