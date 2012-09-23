using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Entities;

namespace UrunYorum.Test.DatabaseObjectTests
{
    [TestClass]
    public class ProductDboTest : DboTestBase
    {
        private ProductRepository repository;
        private ProductDataService dataService;

        private ManufacturerRepository manufacturerRepository;
        private UserRepository userRepository;

        public ProductDboTest()
        {
            repository = new ProductRepository(DbContextFactory);
            manufacturerRepository = new ManufacturerRepository(DbContextFactory);
            userRepository = new UserRepository(DbContextFactory);

            dataService  = new ProductDataService(repository, UnitOfWork);
        }

        [Priority(10), TestMethod]
        public void AddProductTest()
        {
            User user = userRepository.Get(u => u.Name == "Sinan YIL");
            Manufacturer manufacturer = manufacturerRepository.Get(m => m.Name == "Sapphire");

            Product newEntity = new Product();
            newEntity.AddedBy = user;
            newEntity.Manufacturer = manufacturer;
            newEntity.InsertDate = DateTime.Now;
            newEntity.IsApporoved = true;
            newEntity.IsDeleted = false;
            newEntity.ShortDescription = "Ekran kartı";
            newEntity.ProductName = "Radeon HD6950 2Gb PCI-e";
            newEntity.ShortDescription = "Güzel güçlü bir kart işte";
            newEntity.FullDescription = "DVI çıkışlardan biri DVI-I ama diğeri DVI-D. Keşke diğeri de DVI-I olsaydı, HDMI çıkışlı bi monitore para vermek zorunda kalmazdım.";
            newEntity.ManufacturingYear = 2010;

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.ProductId);
        }
    }
}
