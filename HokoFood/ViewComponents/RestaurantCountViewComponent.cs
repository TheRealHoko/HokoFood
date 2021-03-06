using HokoFood.Data;
using Microsoft.AspNetCore.Mvc;

namespace HokoFood.ViewComponents
{
	public class RestaurantCountViewComponent
		: ViewComponent
	{
		private readonly IRestaurantData restaurantData;

		public RestaurantCountViewComponent(IRestaurantData restaurantData)
		{
			this.restaurantData = restaurantData;
		}
		
		public IViewComponentResult Invoke()
		{
			var count = restaurantData.GetCountOfRestaurants();
			return View(count);
		}
	}
}
