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
    public class IndexModel : PageModel
    {
        private readonly HokoFood.Data.HokoFoodDbContext _context;

        public IndexModel(HokoFood.Data.HokoFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Restaurants != null)
            {
                Restaurant = await _context.Restaurants.ToListAsync();
            }
        }
    }
}
