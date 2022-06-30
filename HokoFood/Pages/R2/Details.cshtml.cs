using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HokoFood.Core;
using HokoFood.Data;

namespace HokoFood.Pages.R2
{
    public class DetailsModel : PageModel
    {
        private readonly HokoFood.Data.HokoFoodDbContext _context;

        public DetailsModel(HokoFood.Data.HokoFoodDbContext context)
        {
            _context = context;
        }

      public Restaurant Restaurant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            else 
            {
                Restaurant = restaurant;
            }
            return Page();
        }
    }
}
