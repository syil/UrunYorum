using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Entities;
using UrunYorum.Base.Utilities;

namespace UrunYorum.Test.DatabaseObjectTests
{
    [TestClass]
    public class CategoryDboTest : DboTestBase
    {
        private CategoryRepository repository;
        private CategoryDataService dataService;

        private ProductRepository productRepository;

        public CategoryDboTest()
        {
            productRepository = new ProductRepository(DbContextFactory);

            repository = new CategoryRepository(DbContextFactory);
            dataService = new CategoryDataService(repository, UnitOfWork);
        }

        [TestMethod]
        public void AddCategoryTest()
        {
            Category newEntity = new Category();
            newEntity.Name = string.Format("Kategori {0}", GetRandom());
            newEntity.IsActive = true;
            newEntity.Description = GetRandomString(10);

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.CategoryId);
        }

        [TestMethod]
        public void AddSubCategoryTest()
        {
            Category parentCategory = dataService.All.OrderBy(c => Guid.NewGuid()).FirstOrDefault();

            Category newEntity = new Category();
            newEntity.Name = string.Format("Kategori {0}", GetRandom());
            newEntity.IsActive = true;
            newEntity.Description = GetRandomString(10);
            newEntity.ParentCategory = parentCategory;

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.IsNotNull(newEntity.CategoryId);
        }
    }
}
