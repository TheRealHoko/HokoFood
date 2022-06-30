using HokoFood.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
	public class HokoFoodDbContextFactory : IDesignTimeDbContextFactory<HokoFoodDbContext>
	{
		public HokoFoodDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<HokoFoodDbContext>();

			optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HokoFood; Integrated Security = True;");

			return new HokoFoodDbContext(optionsBuilder.Options);
		}
	}
}
