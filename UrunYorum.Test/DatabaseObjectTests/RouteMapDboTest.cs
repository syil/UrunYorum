using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Entities;
using UrunYorum.Base.Utilities;

namespace UrunYorum.Test.DatabaseObjectTests
{
    [TestClass]
    public class RouteMapDboTest : DboTestBase
    {
        private RouteMapRepository repository;
        private RouteMapDataService dataService;

        private ProductRepository productRepository;
        private ManufacturerRepository manufacturerRepository;
        private UserRepository userRepository;

        public RouteMapDboTest()
        {
            productRepository = new ProductRepository(DbContextFactory);
            manufacturerRepository = new ManufacturerRepository(DbContextFactory);
            userRepository = new UserRepository(DbContextFactory);

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
            newEntity.Slug = string.Format("{0}_{1}", StringOperations.UrlFriendlyString(product.ProductName), StringOperations.GetRandomString(5));

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.RouteMapId);
        }
    }
}
