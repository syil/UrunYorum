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
            newEntity.ShortDescription = GetRandomString(6);
            newEntity.ProductName = "Ürün {0}".FormatWith(GetRandom());
            newEntity.FullDescription = GetRandomString(26);
            newEntity.ManufacturingYear = GetRandom(2008, 2012);

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.ProductId);
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
    }
}
