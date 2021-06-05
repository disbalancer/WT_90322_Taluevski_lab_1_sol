using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT_90322_Taluevski_lab_1.DAL.Entities;
using WT_90322_Taluevski_lab_1.Extensions;
using WT_90322_Taluevski_lab_1.Models;
using WT_90322_Taluevski_lab_1.DAL.Data;

namespace WT_90322_Taluevski_lab_1.Controllers
{
    public class ProductController : Controller
    {
        //public List<Car> _cars;
        //List<CarGroup> _carGroups;

        ApplicationDbContext _context;

        int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            //SetupData();
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {

            var carsFiltered = _context.Cars
                    .Where(d => !group.HasValue || d.CarGroupId == group.Value);

            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.CarGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Car>.GetModel(carsFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);



        }
    }
}
