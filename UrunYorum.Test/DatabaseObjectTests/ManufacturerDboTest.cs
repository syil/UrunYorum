using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Entities;
using UrunYorum.Base;
using UrunYorum.Base.Utilities;

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

        [TestMethod]
        public void AddRouteMapForManufacturer()
        {
            Manufacturer manufacturer = repository.GetMany(m => m.RouteMapInfo == null).OrderBy(m => Guid.NewGuid()).FirstOrDefault();

            if (manufacturer != null)
            {
                RouteMap newEntity = new RouteMap();
                newEntity.InsertDate = DateTime.Now;
                newEntity.ItemType = typeof(Manufacturer).FullName;
                newEntity.ItemId = manufacturer.ManufacturerId;
                newEntity.Slug = "{0}".FormatWith(StringOperations.UrlFriendlyString(manufacturer.Name));

                manufacturer.RouteMapInfo = newEntity;

                dataService.Update(manufacturer);
                dataService.Save();

                Assert.IsNotNull(newEntity.RouteMapId);
            }
            else
            {
                Assert.Inconclusive("Rota atanacak üretici bilgisi kalmadı");
            }
        }
    }
}
