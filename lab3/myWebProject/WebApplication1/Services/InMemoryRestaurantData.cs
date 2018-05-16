using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class InMemoryRestaurantData :IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Andy's Pizza"},
                new Restaurant {Id = 2, Name = "La Placinte"},
                new Restaurant {Id = 3, Name = "Fast Kebab"}
            };
        }
        

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
           return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
