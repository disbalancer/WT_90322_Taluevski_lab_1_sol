using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT_90322_Taluevski_lab_1.DAL.Entities;

namespace WT_90322_Taluevski_lab_1.Controllers
{
    public class ProductController : Controller
    {
        List<Car> _cars;
        List<CarGroup> _carGroups;

        public ProductController()
        {
            SetupData();
        }


        public IActionResult Index()
        {
            return View(_cars);
        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _carGroups = new List<CarGroup>
             {
             new CarGroup {CarGroupId=1, GroupName="Легковые"},
             new CarGroup {CarGroupId=2, GroupName="Грузовые"},
             new CarGroup {CarGroupId=3, GroupName="Мотоциклы"},
             new CarGroup {CarGroupId=4, GroupName="Спецтехника"}
             };
                        _cars = new List<Car>
             {
             new Car {CarId = 1, CarName="Ford Mustang Shelby GT500",
            Description="Mustang Shelby представляют из себя модифицированные версии Форд Мустанг, доработанные специалистами компании Shelby American, основателем которой является американский гонщик Кэролл Шелби.",
            HorsePower=550, CarGroupId=1, Image="ford_mustang.jpg" },
            new Car { CarId = 2, CarName="Volvo FH16",
            Description="Флагман отрасли и настоящая рабочая лошадка — этот автомобиль стал еще совершеннее. Он способен перевозить грузы общим весом до 325 тонн.",
            HorsePower =750, CarGroupId=2, Image="Volvo_FH16.jpg" },
            new Car { CarId = 3, CarName="Harley Davidson V-Rod ",
            Description="Броский, агрессивный дизайн мужского мотоцикла. Мощный и современный двигатель в сочетании с великолепным шасси. Великолепные тормоза, легко справляющиеся с высокой массой мотоцикла.",
            HorsePower =125, CarGroupId=3, Image="Harley-Davidson V-Rod.jpg" },
            new Car { CarId = 4, CarName="T-170",
            Description="Cоветский промышленный трактор,",
            HorsePower =180, CarGroupId=4, Image="T-170.jpg" },
            new Car { CarId = 5, CarName="Opel Astra H",
            Description="Третье поколение легкового автомобиля компактного класса Opel Astra,",
            HorsePower =140, CarGroupId=1, Image="opel_astra.jpg" },
            new Car { CarId = 6, CarName="Chevrolet Camaro 1969",
            Description="Культовый американский спортивный автомобиль, pony car, выпускаюшийся подразделением Chevrolet корпорации General Motors.",
            HorsePower =375, CarGroupId=1, Image="chevrolet_camaro.jpg" }
             };
        }

    }
}
