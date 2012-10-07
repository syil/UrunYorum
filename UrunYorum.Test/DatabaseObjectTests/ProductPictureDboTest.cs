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
    public class ProductPictureDboTest : DboTestBase
    {
        private ProductPictureRepository repository;
        private ProductPictureDataService dataService;

        private UserRepository userRepository;
        private ProductRepository productRepository;

        public ProductPictureDboTest()
        {
            repository = new ProductPictureRepository(DbContextFactory);
            userRepository = new UserRepository(DbContextFactory);
            productRepository = new ProductRepository(DbContextFactory);

            dataService = new ProductPictureDataService(repository, UnitOfWork);
        }

        [TestMethod]
        public void AddProductPictureTest()
        {
            Product product = productRepository.All.OrderBy(p => Guid.NewGuid()).FirstOrDefault();
            User user = userRepository.All.OrderBy(u => Guid.NewGuid()).FirstOrDefault();

            ProductPicture newEntity = new ProductPicture();
            newEntity.InsertDate = DateTime.Now;
            newEntity.IsApproved = true;
            newEntity.IsDefaultPicture = false;
            newEntity.PicturePath = "";
            newEntity.Product = product;
            newEntity.AddedBy = user;

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.AreNotEqual(Guid.Empty, newEntity.ProductPictureId);
        }

        [TestMethod]
        public void ReadProductPicture()
        {
            List<ProductPicture> productPictures = repository.All.ToList();

            if (productPictures.Count > 0)
            {
                CollectionAssert.AllItemsAreNotNull(productPictures.Select(r => r.AddedBy).ToList());
                CollectionAssert.AllItemsAreNotNull(productPictures.Select(r => r.Product).ToList());
            }
            else
            {
                Assert.Inconclusive("Ürün resmi nesnesi bulunmuyor");
            }
        }
    }
}
