using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Data.Contractor;
using UrunYorum.Data.Entities;
using UrunYorum.Base.Utilities;
using UrunYorum.Base;

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

            Assert.AreNotEqual(Guid.Empty, newEntity.CategoryId);
        }

        [TestMethod]
        public void AddSubCategoryTest()
        {
            Category parentCategory = dataService.FindMany(c => c.ParentCategoryId == null).OrderBy(c => Guid.NewGuid()).FirstOrDefault();

            Category newEntity = new Category();
            newEntity.Name = "Kategori {0}".FormatWith(GetRandom());
            newEntity.IsActive = true;
            newEntity.Description = GetRandomString(10);
            newEntity.ParentCategory = parentCategory;

            dataService.Insert(newEntity);
            dataService.Save();

            Assert.AreNotEqual(Guid.Empty, newEntity.CategoryId);
        }

        [TestMethod]
        public void AddRouteMapForCategory()
        {
            Category category = repository.FindMany(c => c.RouteMapInfo == null).OrderBy(c => Guid.NewGuid()).FirstOrDefault();

            if (category != null)
            {
                RouteMap newEntity = new RouteMap();
                newEntity.InsertDate = DateTime.Now;
                newEntity.ItemType = typeof(Category).FullName;
                newEntity.ItemId = category.CategoryId;
                newEntity.Slug = StringOperations.UrlFriendlyString(category.Name);

                category.RouteMapInfo = newEntity;

                dataService.Update(category);
                dataService.Save();

                Assert.AreNotEqual(Guid.Empty, newEntity.RouteMapId); 
            }
            else
            {
                Assert.Inconclusive("Rota atanacak kategori bilgisi kalmadı");
            }
        }
    }
}
