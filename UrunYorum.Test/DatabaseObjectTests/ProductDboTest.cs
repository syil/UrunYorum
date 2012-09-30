using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Entities;
using UrunYorum.Base;
using UrunYorum.Base.Utilities;

namespace UrunYorum.Test.DatabaseObjectTests
{
    [TestClass]
    public class ProductDboTest : DboTestBase
    {
        private ProductRepository repository;
        private ProductDataService dataService;

        private ManufacturerRepository manufacturerRepository;
        private CategoryRepository categoryRepository;
        private UserRepository userRepository;

        public ProductDboTest()
        {
            repository = new ProductRepository(DbContextFactory);
            manufacturerRepository = new ManufacturerRepository(DbContextFactory);
            userRepository = new UserRepository(DbContextFactory);
            categoryRepository = new CategoryRepository(DbContextFactory);

            dataService  = new ProductDataService(repository, UnitOfWork);
        }

        [TestMethod]
        public void AddProductTest()
        {
            User user = userRepository.All.OrderBy(u => Guid.NewGuid()).FirstOrDefault(); // Random User
            Manufacturer manufacturer = manufacturerRepository.All.OrderBy(m => Guid.NewGuid()).FirstOrDefault(); // Random Manufacturer

            Product newEntity = new Product();
            newEntity.AddedBy = user;
            newEntity.Manufacturer = manufacturer;
            newEntity.InsertDate = DateTime.Now;
            newEntity.IsApporoved = true;
            newEntity.IsDeleted = false;
            newEntity.ShortDescription = GetRandomString(GetRandom(3,5));
            newEntity.ProductName = "Ürün {0}".FormatWith(GetRandom());
            newEntity.FullDescription = GetRandomString(GetRandom(10,25));
            newEntity.ManufacturingYear = GetRandom(2008, 2012);

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.AreNotEqual(Guid.Empty, newEntity.ProductId);
        }

        [TestMethod]
        public void AssignCategoryTest()
        {
            Category category = categoryRepository.All.OrderBy(c => Guid.NewGuid()).FirstOrDefault();
            Product product = dataService.All.OrderBy(p => Guid.NewGuid()).FirstOrDefault();
            int assignedCategoryCount = product.Categories.Count;

            product.Categories.Add(category);

            dataService.Update(product);
            dataService.Save();

            Assert.AreNotEqual(assignedCategoryCount, product.Categories.Count);
        }

        [TestMethod]
        public void AddRouteMapForProduct()
        {
            Product product = repository.GetMany(p => p.RouteMapInfo == null).OrderBy(p => Guid.NewGuid()).FirstOrDefault();

            if (product != null)
            {
                RouteMap newEntity = new RouteMap();
                newEntity.InsertDate = DateTime.Now;
                newEntity.ItemType = typeof(Product).FullName;
                newEntity.ItemId = product.ProductId;
                newEntity.Slug = "{0}-{1}".FormatWith(StringOperations.UrlFriendlyString(product.ProductName), StringOperations.GetRandomString(2));

                product.RouteMapInfo = newEntity;

                dataService.Update(product);
                dataService.Save();

                Assert.AreNotEqual(Guid.Empty, newEntity.RouteMapId); 
            }
            else
            {
                Assert.Inconclusive("Rota atanacak ürün bilgisi kalmadı");
            }
        }
    }
}
