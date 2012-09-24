using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Entities;

namespace UrunYorum.Test.DatabaseObjectTests
{
    [TestClass]
    public class UserDboTest : DboTestBase
    {
        private UserRepository repository;
        private UserDataService dataService;

        public UserDboTest()
        {
            repository = new UserRepository(DbContextFactory);
            dataService = new UserDataService(repository, UnitOfWork);
        }

        [TestMethod]
        public void AddUserTest()
        {
            User newEntity = new User();
            newEntity.IsActive = true;
            newEntity.IsDeleted = false;
            newEntity.Name = string.Format("Kullanıcı {0}", GetRandom());
            newEntity.RegisterDate = DateTime.Now;

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.UserId);
        }
    }
}
