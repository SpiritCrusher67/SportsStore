using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportsStore.Components;
using SportsStore.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
            new Product {ProductId = 1, Name = "Pl", Category = "Apples" },
            new Product { ProductId = 2, Name = "Р2", Category = "Apples" },
            new Product {ProductId = 3, Name = "РЗ", Category = "Plums"},
            new Product {ProductId = 4, Name = "Р4", Category = "Oranges" },
            }));

            var target = new NavigationMenuViewComponent(mock.Object);

            var result = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();

            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plums" }, result));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            var categoryToSelect = "Apples";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
            new Product {ProductId = 1, Name = "Pl", Category = "Apples" },
            new Product { ProductId = 2, Name = "Р2", Category = "Apples" }
            }));

            var target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;

            var result = (string)(target.Invoke() as ViewViewComponentResult)
                .ViewData["SelectedCategory"];

            Assert.Equal(categoryToSelect, result);
        }
    }
}
