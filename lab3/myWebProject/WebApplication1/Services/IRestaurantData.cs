using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant restaurant);
        Restaurant Update(Restaurant restaurant);
    }
}
