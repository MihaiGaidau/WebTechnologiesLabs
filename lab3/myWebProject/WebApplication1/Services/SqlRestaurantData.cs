using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SqlRestaurantData:IRestaurantData
    {
        private WebApplication1DbContext _context;

        public SqlRestaurantData(WebApplication1DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
           return  _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var _myrest = new Restaurant()
            {
                Id = restaurant.Id,
                Cuisine = restaurant.Cuisine,
                Name = restaurant.Name
            };
            _context.Restaurants.Attach(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }
    }
}
