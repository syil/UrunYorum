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

        [TestMethod]
        public void AddManufacturerTest()
        {
            int randomManufacturerNumber = GetRandom();

            Manufacturer newEntity = new Manufacturer();
            newEntity.FullName = string.Format("Marka {0} Technology Ltd.", randomManufacturerNumber);
            newEntity.Name = string.Format("Marka {0}", randomManufacturerNumber);
            newEntity.IsActive = true;
            newEntity.InsertDate = DateTime.Now;
            newEntity.WebsiteURL = string.Format("http://www.marka{0}.com", randomManufacturerNumber);

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.ManufacturerId);
        }
    }
}
