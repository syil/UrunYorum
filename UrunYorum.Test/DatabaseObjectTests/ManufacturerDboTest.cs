using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Entities;
using UrunYorum.Base;

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

        [TestMethod]
        public void AddManufacturerTest()
        {
            int randomManufacturerNumber = GetRandom();

            Manufacturer newEntity = new Manufacturer();
            newEntity.FullName = "Marka {0} Technology Ltd.".FormatWith(randomManufacturerNumber);
            newEntity.Name = "Marka {0}".FormatWith(randomManufacturerNumber);
            newEntity.IsActive = true;
            newEntity.InsertDate = DateTime.Now;
            newEntity.WebsiteURL = "http://www.marka{0}.com".FormatWith(randomManufacturerNumber);

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.ManufacturerId);
        }
    }
}
