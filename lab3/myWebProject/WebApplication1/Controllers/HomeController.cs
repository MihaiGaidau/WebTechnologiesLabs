using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController:Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greater;

        public HomeController(IRestaurantData restaurantData, IGreeter greater)
        {
            _restaurantData = restaurantData;
            _greater = greater; 
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greater.GetTheMessageOfheDay(); 
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
//                 return View("NotFound");
//                return NotFound();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {

                var newRestaurant = new Restaurant {Name = model.Name, Cuisine = model.Cuisine};
                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction(nameof(Details), new {id = newRestaurant.Id});
            }
            else
            {
                return View();
            }
        }  
    }
}
