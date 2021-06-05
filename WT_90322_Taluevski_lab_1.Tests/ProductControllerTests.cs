using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WT_90322_Taluevski_lab_1.Controllers;
using WT_90322_Taluevski_lab_1.DAL.Entities;
using Xunit;


namespace WT_90322_Taluevski_lab_1.Tests
{
    public class ProductControllerTests
    {
        [Theory]
            //[InlineData(1, 3, 1)] // 1-я страница, кол. объектов 3, id первого объекта 1
            //[InlineData(2, 2, 4)] // 2-я страница, кол. объектов 2, id первого объекта 4
            [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]


        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            var controller = new ProductController();
            controller._cars = TestData.GetCarsList();

            // Act
            var result = controller
                                .Index(pageNo:page, group:null) as ViewResult;
            var model = result?.Model as List<Car>;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].CarId);
        }


        [Fact]
        public void ControllerSelectsGroup()
        {
            // Arrange
            var controller = new ProductController();
            var data = TestData.GetCarsList();
            controller._cars = data;
            var comparer = Comparer<Car>
                    .GetComparer((d1, d2) => d1.CarId.Equals(d2.CarId));
            
            // Act
            var result = controller.Index(2) as ViewResult;
            var model = result.Model as List<Car>;
            
            // Assert
            Assert.Equal(2, model.Count);
            Assert.Equal(data[2], model[0], comparer);
        }

    }
}
