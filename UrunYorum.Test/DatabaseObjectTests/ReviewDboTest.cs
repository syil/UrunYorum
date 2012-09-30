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
    public class ReviewDboTest : DboTestBase
    {
        private ReviewRepository repository;
        private ReviewDataService dataService;

        private UserRepository userRepository;
        private ProductRepository productRepository;

        public ReviewDboTest()
        {
            repository = new ReviewRepository(DbContextFactory);
            userRepository = new UserRepository(DbContextFactory);
            productRepository = new ProductRepository(DbContextFactory);

            dataService = new ReviewDataService(repository, UnitOfWork);
        }

        [TestMethod]
        public void AddToReview()
        {
            Product product = productRepository.All.OrderBy(p => Guid.NewGuid()).FirstOrDefault();
            User user = userRepository.All.OrderBy(u => Guid.NewGuid()).FirstOrDefault();

            Review newEntity = new Review();
            newEntity.InsertDate = DateTime.Now;
            newEntity.IsApproved = true;
            newEntity.IsDeleted = false;
            newEntity.Product = product;
            newEntity.ReviewText = GetRandomString(GetRandom(10, 100));
            newEntity.SenderIP = "127.0.0.1";
            newEntity.Title = GetRandomString(GetRandom(3));
            newEntity.User = user;
            newEntity.HelpfullVoteCount = GetRandom(10);
            newEntity.UnhelpfullVoteCount = GetRandom(10);
            
            dataService.Insert(newEntity);
            dataService.Save();

            Assert.AreNotEqual(Guid.Empty, newEntity.ReviewId);
        }
    }
}
