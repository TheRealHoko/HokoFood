using HokoFood.Core;

namespace HokoFood.Data
{
	public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Hoko's Restaurant", Location = "Paris", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Kaiser's Restaurant", Location = "Lille", Cuisine = CuisineType.Indian},
                new Restaurant { Id = 3, Name = "Pablo's Restaurant", Location = "Lyon", Cuisine = CuisineType.Mexican }
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
		{
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
		}
        public Restaurant GetById(int id)
		{
            return restaurants.SingleOrDefault(r => r.Id == id)!;
		}
        public Restaurant Update(Restaurant updatedRestaurant)
		{
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
			{
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
			}
            return restaurant!;
		}
        public int Commit()
		{
            return 0;
		}
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null!)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name!.StartsWith(name)
                   orderby r.Name
                   select r;
        }

		public Restaurant Delete(int id)
		{
			var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
			{
                restaurants.Remove(restaurant);
			}
            return restaurant!;
		}

		public int GetCountOfRestaurants()
		{
			return restaurants.Count();
		}
	}
}
