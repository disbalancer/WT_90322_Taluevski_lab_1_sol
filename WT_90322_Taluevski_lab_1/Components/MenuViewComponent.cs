using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT_90322_Taluevski_lab_1.Models;

namespace WT_90322_Taluevski_lab_1.Components
{
    public class MenuViewComponent : ViewComponent
    {

        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{Controller="Home", Action="Index", Text="Lab2"},
            new MenuItem{Controller="Product", Action="Index", Text="Каталог"},
            new MenuItem{Controller="Admin", Action="/Index", Text="Администрирование"}
        };

        public IViewComponentResult Invoke()
        {
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];

            foreach (var item in _menuItems)
            {
                // Название контроллера совпадает?
                var _matchController = controller?.Equals(item.Controller) ?? false;

                // Название зоны совпадает?
                var _matchArea = area?.Equals(item.Area) ?? false;

                // Если есть совпад., то сделать элем меню активным(применить соотв. класс CSS)
                if (_matchController || _matchArea)
                {
                    item.Active = "active";
                }
            }
            return View(_menuItems);
        }

    }
}
