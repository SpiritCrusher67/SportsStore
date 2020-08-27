using System;
using Xunit;
using Moq;
using SportsStore.Models;
using SportsStore.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Models.ViewModels;
using Castle.DynamicProxy.Generators;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductId = 1, Name = "P1" } ,
                new Product { ProductId = 2, Name = "P2"},
                new Product { ProductId = 3, Name = "P3"},
                new Product { ProductId = 4, Name = "P4"},
                new Product { ProductId = 5, Name = "P5"},
            });
            var controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            var result = controller.List(null,2).ViewData.Model as ProductsListViewModel;

            var prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductId = 1, Name = "P1" } ,
                new Product { ProductId = 2, Name = "P2"},
                new Product { ProductId = 3, Name = "P3"},
                new Product { ProductId = 4, Name = "P4"},
                new Product { ProductId = 5, Name = "P5"},
            });

            var controller = new ProductController(mock.Object) { PageSize = 3 };

            var result = controller.List(null,2).ViewData.Model as ProductsListViewModel;

            var pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }

        [Fact]
        public void Can_Filter_Products()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductId = 1, Name = "P1", Category = "Cat1"} ,
                new Product { ProductId = 2, Name = "P2", Category = "Cat2"},
                new Product { ProductId = 3, Name = "P3", Category = "Cat1"},
                new Product { ProductId = 4, Name = "P4", Category = "Cat2"},
                new Product { ProductId = 5, Name = "P5", Category = "Cat3"},
            });

            var controller = new ProductController(mock.Object) { PageSize = 3 };

            var result = 
                (controller.List("Cat2", 1).ViewData.Model as ProductsListViewModel)
                .Products.ToArray();

            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
        }

        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductId = 1, Name = "P1", Category = "Cat1"} ,
                new Product { ProductId = 2, Name = "P2", Category = "Cat2"},
                new Product { ProductId = 3, Name = "P3", Category = "Cat1"},
                new Product { ProductId = 4, Name = "P4", Category = "Cat2"},
                new Product { ProductId = 5, Name = "P5", Category = "Cat3"},
            });

            var target = new ProductController(mock.Object) { PageSize = 3 };

            Func<ViewResult, ProductsListViewModel> GetModel = r => 
                r?.ViewData?.Model as ProductsListViewModel;

            var res1 = GetModel(target.List("Cat1"))?.PagingInfo.TotalItems;
            var res2 = GetModel(target.List("Cat2"))?.PagingInfo.TotalItems;
            var res3 = GetModel(target.List("Cat3"))?.PagingInfo.TotalItems;
            var resAll = GetModel(target.List(null))?.PagingInfo.TotalItems;

            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll) ;
        }
    }
}
