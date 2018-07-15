using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SportsStore.Models;
using System.Linq;
using SportsStore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace SportsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        IQueryable<Product> products = new Product[]
            {
                new Product{ProductID = 1, Name = "P1", Category = "Soccer"},
                new Product{ProductID = 2, Name = "P2", Category = "Rugby"},
                new Product{ProductID = 3, Name = "P3", Category = "Box"},
                new Product{ProductID = 4, Name = "P4", Category = "SkySport"},
                new Product{ProductID = 5, Name = "P5", Category = "Rugby"}
            }.AsQueryable();

        [Fact]
        public void Can_Select_Categories()
        {
            //Arrang
            
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(r => r.Products).Returns(products);

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);


            //Act
            string[] result = (((target.Invoke() as ViewViewComponentResult)
                .ViewData.Model as CategoryListViewModel).Categories).ToArray();

            //Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Box", "Rugby", "SkySport", "Soccer" }, result));

        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(products);

            string categoryToSelect = "Rugby";

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };

            target.RouteData.Values["category"] = categoryToSelect;

            //Act

            string result = ((target.Invoke() as ViewViewComponentResult).ViewData.Model
                as CategoryListViewModel).CurrentCategory;

            //Assert
            Assert.Equal(categoryToSelect, result);
            
        }
    }
}
