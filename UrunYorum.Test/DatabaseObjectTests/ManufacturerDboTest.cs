using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Entities;

namespace UrunYorum.Test.DatabaseObjectTests
{
    [TestClass]
    public class ManufacturerDboTest : DboTestBase
    {
        private ManufacturerRepository repository;
        private ManufacturerDataService dataService;

        public ManufacturerDboTest()
        {
            repository = new ManufacturerRepository(DbContextFactory);
            dataService = new ManufacturerDataService(repository, UnitOfWork);
        }

        [Priority(100), TestMethod]
        public void AddManufacturerTest()
        {
            Manufacturer newEntity = new Manufacturer();
            newEntity.FullName = "Sapphire Technology Ltd.";
            newEntity.Name = "Sapphire";
            newEntity.IsActive = true;
            newEntity.InsertDate = DateTime.Now;
            newEntity.WebsiteURL = "http://www.sapphire.com";

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.ManufacturerId);
        }
    }
}
