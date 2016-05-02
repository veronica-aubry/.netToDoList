using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using WebApplication1.Controllers;
using WebApplication1.Models;
using Xunit;
using Moq;
using System.Linq;
using System;

namespace WebApplication1.Tests
{
    public class ItemTest
    {
        [Fact]
        public void Get_ModelListItemIndex_Test()
        {
            //Arrange
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new Item[]
                {
                    new Item {ItemId = 1, Description = "Wash the dog" },
                    new Item {ItemId = 2, Description = "Do the dishes" },
                    new Item {ItemId = 3, Description = "Sweep the floor" }
                }.AsQueryable());
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;


            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Item>>(result);
        }
    }
}
