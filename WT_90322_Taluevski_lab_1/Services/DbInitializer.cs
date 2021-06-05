using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT_90322_Taluevski_lab_1.DAL.Data;
using WT_90322_Taluevski_lab_1.DAL.Entities;

namespace WT_90322_Taluevski_lab_1.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                      UserManager<ApplicationUser> userManager,
                                      RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.CarGroups.Any())
            {
                context.CarGroups.AddRange(
                new List<CarGroup>
                {
                     new CarGroup {GroupName="Легковые"},
                     new CarGroup {GroupName="Грузовые"},
                     new CarGroup {GroupName="Мотоциклы"},
                     new CarGroup {GroupName="Спецтехника"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                new List<Car>
                {
                    new Car {CarName="Ford Mustang Shelby GT500",
                    Description="Mustang Shelby представляют из себя модифицированные версии Форд Мустанг, доработанные специалистами компании Shelby American, основателем которой является американский гонщик Кэролл Шелби.",
                    HorsePower=168200, CarGroupId=1, Image="ford_mustang.jpg" },
                    new Car {CarName="Volvo FH16",
                    Description="Флагман отрасли и настоящая рабочая лошадка — этот автомобиль стал еще совершеннее. Он способен перевозить грузы общим весом до 325 тонн.",
                    HorsePower =75700, CarGroupId=2, Image="Volvo_FH16.jpg" },
                    new Car {CarName="Harley Davidson V-Rod ",
                    Description="Броский, агрессивный дизайн мужского мотоцикла. Мощный и современный двигатель в сочетании с великолепным шасси. Великолепные тормоза, легко справляющиеся с высокой массой мотоцикла.",
                    HorsePower =28500, CarGroupId=3, Image="Harley-Davidson V-Rod.jpg" },
                    new Car { CarName="Бульдозер T-170",
                    Description="Cоветский промышленный трактор,",
                    HorsePower =118100, CarGroupId=4, Image="T-170.jpg" },
                    new Car {CarName="Opel Astra H",
                    Description="Третье поколение легкового автомобиля компактного класса Opel Astra,",
                    HorsePower =7000, CarGroupId=1, Image="opel_astra.jpg" },
                    new Car { CarName="Chevrolet Camaro 1969",
                    Description="Культовый американский спортивный автомобиль, pony car, выпускаюшийся подразделением Chevrolet корпорации General Motors.",
                    HorsePower =37500, CarGroupId=1, Image="chevrolet_camaro.jpg" },
                    new Car { CarName="ЗАЗ-968",
                    Description="Советский автомобиль I группы малого класса, выпускавшийся Запорожским автомобильным заводом.",
                    HorsePower =600, CarGroupId=1, Image="zaz_968.jpg" },
                    new Car { CarName="Kawasaki Ninja 650",
                    Description="Новая легковесная решетчатая рама Trellis, двухцилиндровый двигатель с жидкостным охлаждением. Идеальное сочетание спортивного исполнения и городской практичности.",
                    HorsePower =6800, CarGroupId=3, Image="kawasaki.jpg" },
                    new Car { CarName="MAN TGX D38",
                    Description="Вас ничто не остановит MAN TGX D38 поможет справиться с задачей любой сложности. Наш мощный автомобиль с многосильным двигателем может принять и перевезти груз до 120 тонн и способен преодолеть крутые склоны за счет тягового усилия. Высокая тормозная мощность тормозов-замедлителей гарантирует безопасный спуск.",
                    HorsePower =89100, CarGroupId=2, Image="man.jpg" },
                    new Car { CarName="Трактор Т-25",
                    Description="Предназначены для предпосевной обработки почвы, посева, посадки овощей, ухода за посевами, междурядной обработкой овощных культур и садов, уборки сена и других сельскохозяйственных и транспортных работ. Они могут также использоваться для привода стационарных машин, погрузочно разгрузочных, дорожных и других работ.",
                    HorsePower =6000, CarGroupId=4, Image="t25.jpg" }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
