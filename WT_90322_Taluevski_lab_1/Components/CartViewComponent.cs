using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT_90322_Taluevski_lab_1.Extensions;
using WT_90322_Taluevski_lab_1.Models;

namespace WT_90322_Taluevski_lab_1.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;

        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }

    }
}
