using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT_90322_Taluevski_lab_1.DAL.Entities;
using WT_90322_Taluevski_lab_1.Extensions;
using WT_90322_Taluevski_lab_1.Models;

namespace WT_90322_Taluevski_lab_1.Controllers
{
    public class ProductController : Controller
    {
        public List<Car> _cars;
        List<CarGroup> _carGroups;

        int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {

            var carsFiltered = _cars
                        .Where(d => !group.HasValue || d.CarGroupId == group.Value);

            // Поместить список групп во ViewData
            ViewData["Groups"] = _carGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Car>.GetModel(carsFiltered, pageNo, _pageSize);
            //if (Request.Headers["x-requested-with"]
            //                                        .ToString()
            //                                        .ToLower()
            //                                        .Equals("xmlhttprequest"))
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);



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
            new Car { CarId = 4, CarName="Бульдозер T-170",
            Description="Cоветский промышленный трактор,",
            HorsePower =180, CarGroupId=4, Image="T-170.jpg" },
            new Car { CarId = 5, CarName="Opel Astra H",
            Description="Третье поколение легкового автомобиля компактного класса Opel Astra,",
            HorsePower =140, CarGroupId=1, Image="opel_astra.jpg" },
            new Car { CarId = 6, CarName="Chevrolet Camaro 1969",
            Description="Культовый американский спортивный автомобиль, pony car, выпускаюшийся подразделением Chevrolet корпорации General Motors.",
            HorsePower =375, CarGroupId=1, Image="chevrolet_camaro.jpg" },
            new Car { CarId = 7, CarName="ЗАЗ-968",
            Description="Советский автомобиль I группы малого класса, выпускавшийся Запорожским автомобильным заводом.",
            HorsePower =27, CarGroupId=1, Image="zaz_968.jpg" },
            new Car { CarId = 8, CarName="Kawasaki Ninja 650",
            Description="Новая легковесная решетчатая рама Trellis, двухцилиндровый двигатель с жидкостным охлаждением. Идеальное сочетание спортивного исполнения и городской практичности.",
            HorsePower =68, CarGroupId=3, Image="kawasaki.jpg" },
            new Car { CarId = 9, CarName="MAN TGX D38",
            Description="Вас ничто не остановит MAN TGX D38 поможет справиться с задачей любой сложности. Наш мощный автомобиль с многосильным двигателем может принять и перевезти груз до 120 тонн и способен преодолеть крутые склоны за счет тягового усилия. Высокая тормозная мощность тормозов-замедлителей гарантирует безопасный спуск.",
            HorsePower =640, CarGroupId=2, Image="man.jpg" },
            new Car { CarId = 10, CarName="Трактор Т-25",
            Description="Предназначены для предпосевной обработки почвы, посева, посадки овощей, ухода за посевами, междурядной обработкой овощных культур и садов, уборки сена и других сельскохозяйственных и транспортных работ. Они могут также использоваться для привода стационарных машин, погрузочно разгрузочных, дорожных и других работ.",
            HorsePower =25, CarGroupId=4, Image="t25.jpg" }
             };
        }

    }
}
