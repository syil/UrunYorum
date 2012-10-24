using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Entities.Enums;

namespace UrunYorum.Test.DatabaseObjectTests
{
    [TestClass]
    public class LoginDboTest : DboTestBase
    {
        private LoginRepository repository;
        private LoginDataService dataService;

        private UserRepository userRepository;

        public LoginDboTest()
        {
            repository = new LoginRepository(DbContextFactory);
            dataService = new LoginDataService(repository, UnitOfWork);

            userRepository = new UserRepository(DbContextFactory);
        }

        [TestMethod]
        public void AddLoginTest()
        {
            User user = userRepository.FindMany(u => u.LoginInfo == null).OrderBy(u => Guid.NewGuid()).FirstOrDefault();

            if (user != null)
            {
                Login newEntity = new Login();
                newEntity.AuthenticateDate = DateTime.Now;
                newEntity.IsAuthenticated = true;
                newEntity.IsDeleted = false;
                newEntity.ProfileURL = "";
                newEntity.UserProvider = UserProvider.Native;
                newEntity.AuthenticateKey = user.Name.Replace(" ", "");
                newEntity.User = user;

                dataService.Insert(newEntity);
                dataService.Save();

                Assert.AreNotEqual(Guid.Empty, newEntity.LoginId); 
            }
            else
            {
                Assert.Inconclusive("Geçerli kullanıcı öğesi bulunamadı");
            }
        }
    }
}
