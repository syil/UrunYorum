using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Entities;
using UrunYorum.Base.Utilities;
using UrunYorum.Base;

namespace UrunYorum.Test.DatabaseObjectTests
{
    [TestClass]
    public class RouteMapDboTest : DboTestBase
    {
        private RouteMapRepository repository;
        private RouteMapDataService dataService;

        private ProductRepository productRepository;
        private ManufacturerRepository manufacturerRepository;
        private CategoryRepository categoryRepository;
        private UserRepository userRepository;

        public RouteMapDboTest()
        {
            productRepository = new ProductRepository(DbContextFactory);
            manufacturerRepository = new ManufacturerRepository(DbContextFactory);
            userRepository = new UserRepository(DbContextFactory);
            categoryRepository = new CategoryRepository(DbContextFactory);

            repository = new RouteMapRepository(DbContextFactory);
            dataService = new RouteMapDataService(repository, UnitOfWork);
        }

        [TestMethod]
        public void AddRouteMapForProduct()
        {
            Product product = productRepository.All.OrderBy(p => Guid.NewGuid()).FirstOrDefault();

            RouteMap newEntity = new RouteMap();
            newEntity.InsertDate = DateTime.Now;
            newEntity.ItemType = typeof(Product).FullName;
            newEntity.ItemId = product.ProductId;
            newEntity.Slug = "{0}_{1}".FormatWith(StringOperations.UrlFriendlyString(product.ProductName), StringOperations.GetRandomString(5));

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.RouteMapId);
        }

        [TestMethod]
        public void AddRouteMapForCategory()
        {
            Category category = categoryRepository.All.OrderBy(c => Guid.NewGuid()).FirstOrDefault();

            RouteMap newEntity = new RouteMap();
            newEntity.InsertDate = DateTime.Now;
            newEntity.ItemType = typeof(Category).FullName;
            newEntity.ItemId = category.CategoryId;
            newEntity.Slug = StringOperations.UrlFriendlyString(category.Name);

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.RouteMapId);
        }
    }
}
