using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT_90322_Taluevski_lab_1.DAL.Entities;
using WT_90322_Taluevski_lab_1.Models;
using Xunit;

namespace WT_90322_Taluevski_lab_1.Tests
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Car>
                                        .GetModel(TestData.GetCarsList(), 1, 3);
            // Assert
            Assert.Equal(2, model.TotalPages);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
                                                    MemberType = typeof(TestData))]
        
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Car>
                                        .GetModel(TestData.GetCarsList(), page, 3);
            // Assert
            Assert.Equal(qty, model.Count);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
                                                    MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Car>
                                        .GetModel(TestData.GetCarsList(), page, 3);
            // Assert
            Assert.Equal(id, model[0].CarId);
        }
    }
}
