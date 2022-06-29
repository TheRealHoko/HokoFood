using HokoFood.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokoFood.Data
{
	public class HokoFoodDbContext : DbContext
	{
		public HokoFoodDbContext(DbContextOptions<HokoFoodDbContext> options)
				: base(options)
		{

		}
		public DbSet<Restaurant> Restaurants { get; set; }
	}
}
