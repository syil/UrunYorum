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
    public class RatingDboTest : DboTestBase
    {
        private RatingRepository repository;
        private RatingDataService dataService;

        private UserRepository userRepository;
        private ProductRepository productRepository;

        public RatingDboTest()
        {
            repository = new RatingRepository(DbContextFactory);
            dataService = new RatingDataService(repository, UnitOfWork);

            userRepository = new UserRepository(DbContextFactory);
            productRepository = new ProductRepository(DbContextFactory);
        }

        [TestMethod]
        public void AddRatingTest()
        {
            Product product = productRepository.All.OrderBy(p => Guid.NewGuid()).FirstOrDefault();
            User user = userRepository.All.OrderBy(u => Guid.NewGuid()).FirstOrDefault();

            Rating newEntity = new Rating();
            newEntity.RatingDate = DateTime.Now;
            newEntity.RatingValue = GetRandom(5);
            newEntity.Product = product;
            newEntity.User = user;

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.AreNotEqual(Guid.Empty, newEntity.RatingId);
        }

        [TestMethod]
        public void ReadRating()
        {
            List<Rating> ratings = repository.All.ToList();

            if (ratings.Count > 0)
            {
                CollectionAssert.AllItemsAreNotNull(ratings.Select(r => r.User).ToList());
                CollectionAssert.AllItemsAreNotNull(ratings.Select(r => r.Product).ToList());
            }
            else
            {
                Assert.Inconclusive("Oy nesnesi bulunmuyor");
            }
        }
    }
}
