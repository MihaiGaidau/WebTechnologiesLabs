using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class AllModel : PageModel
    {
        private IRestaurantData _restaurants;
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public AllModel(IRestaurantData restaurants)
        {
            _restaurants = restaurants;
        }
        public void OnGet()
        {
            Restaurants = _restaurants.GetAll();
        }
    }
}