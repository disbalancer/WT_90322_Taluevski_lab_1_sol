using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using WT_90322_Taluevski_lab_1.Controllers;
using WT_90322_Taluevski_lab_1.DAL.Entities;
//using Xunit;

namespace WT_90322_Taluevski_lab_1.Tests
{
    public class TestData
    {
        public static List<Car> GetCarsList()
        {
            return new List<Car>
                                 {
                                 new Car{ CarId=1, CarGroupId=1},
                                 new Car{ CarId=2, CarGroupId=1},
                                 new Car{ CarId=3, CarGroupId=2},
                                 new Car{ CarId=4, CarGroupId=2},
                                 new Car{ CarId=5, CarGroupId=3}
                                 };
        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }
    }
}
