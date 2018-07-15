using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        #region Fake Repository
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                // not required for test
            }

            public void AddProducts(IEnumerable<Product> products)
            {
                // not required for test
            }
        }
        #endregion

        [Theory]
        //[InlineData(275, 48.95, 19.50, 24.95)]
        //[InlineData(5, 48.95, 19.50, 24.95)]
        //[MemberData(nameof(memberName))]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsCompleate(IEnumerable<Product> products)
        {
            //Arrange of moq
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController() { Repository = mock.Object };

            //Arrange of fake repository
            //var controller = new HomeController();
            //controller.Repository = new ModelCompleteFakeRepository
            //{
            //    Products = products
            //};

            //Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(controller.Repository.Products.Where(p => p.Price < 50), model,
                Comparer.Get<Product>(
                    (p1, p2) =>
                    {
                        return p1.Name == p2.Name && p1.Price == p2.Price;
                    }
                    ));
        }

        #region Fake Repository
        //class PropertyOnceFakeRepository : IRepository
        //{
        //    public int PropertyCounter { get; set; } = 0;

        //    public IEnumerable<Product> Products
        //    {
        //        get
        //        {
        //            PropertyCounter++;
        //            return new[] { new Product { Name = "P1", Price = 100 } };
        //        }
        //    }

        //    public void AddProduct(Product product)
        //    {
        //        // do nothing - not required for test
        //    }

        //    public void AddProducts(IEnumerable<Product> products)
        //    {
        //        // do nothing - not required for test
        //    }
        //}
        #endregion

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange of moq 
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] { new Product { Name = "P1", Price = 100 } });
            var controller = new HomeController() { Repository = mock.Object };

            //Arrange of fake repository
            //var repo = new PropertyOnceFakeRepository();
            //var controller = new HomeController() { Repository = repo };

            //Act
            var result = controller.Index();

            //Assert
            //Assert.Equal(1, repo.PropertyCounter);
            mock.VerifyGet(m => m.Products, Times.Once);
        }

    }
}
