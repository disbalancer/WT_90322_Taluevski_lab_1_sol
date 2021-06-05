using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WT_90322_Taluevski_lab_1.DAL.Data;
using WT_90322_Taluevski_lab_1.DAL.Entities;

namespace WT_90322_Taluevski_lab_1.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WT_90322_Taluevski_lab_1.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(WT_90322_Taluevski_lab_1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(c => c.Group).FirstOrDefaultAsync(m => m.CarId == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
