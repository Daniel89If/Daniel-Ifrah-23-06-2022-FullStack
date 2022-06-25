using WeatherWeb.Data;
using WeatherWeb.Entities;
using WeatherWeb.Managers;
using WeatherWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WeatherWeb.Controllers
{
    public class WeatherController : Controller
    {
        private CitiesMng citiesMng;
        private readonly ApplicationDbContext _db;
        private static string currentUser;

        public WeatherController(ApplicationDbContext db)
        {
            _db = db;
        }
        //GET
        public IActionResult Search()
        {
            return View();
        }

        //POST
        [HttpGet]
        public IActionResult SearchGet(string city)
        {
            ViewData["City"] = city;
            if (String.IsNullOrEmpty(city)) {

                return RedirectToAction("Search");
            }

            citiesMng = new CitiesMng();
            string jsonStringKey = citiesMng.getCityIdResponse(city);

            List<AutocompleteObj> autocompleteObj = JsonConvert.DeserializeObject<List<AutocompleteObj>>(jsonStringKey);
            if (autocompleteObj.Count() == 0)
            {
                TempData["Faild"] = "Bad Request";

                return RedirectToAction("Search");
            }
            int cityId = Int32.Parse(autocompleteObj[0].Key);
            var cityFromDb = _db.cities.Where(s => s.Id == cityId).FirstOrDefault();

            if (cityFromDb != null)
            {
                return View(cityFromDb);
            }
            else
            {
                string jsonStringInfo = citiesMng.getCityInfo(autocompleteObj[0].Key);

                List<CityInfoObj> cityInfoObj = JsonConvert.DeserializeObject<List<CityInfoObj>>(jsonStringInfo);
                if (cityInfoObj.Count() == 0)
                {
                    TempData["Faild"] = "Bad Request";

                    return RedirectToAction("Search");
                }

                City newCity = new City();
                newCity.Id = cityId;
                newCity.Name = autocompleteObj[0].LocalizedName;
                newCity.WeatherText = cityInfoObj[0].WeatherText;
                newCity.Temperature = cityInfoObj[0].Temperature.Metric.Value;

                _db.cities.Add(newCity);
                _db.SaveChanges();
                TempData["success"] = "Create is success";

                return View(newCity);
            }
        }

        //GET
        public IActionResult Favorite(string userName)
        {
            if (userName != null)
            {
                currentUser = userName;
            }

            IEnumerable<Favorite> objFavoriteList = _db.favorites.Where(f => f.UserName == currentUser);
            if (objFavoriteList.Any())
            {
                return View(objFavoriteList);
            }

            return RedirectToAction("Search");
        }


        [HttpPost]
        public IActionResult AddToFavorite(string cityName)
        {
            
            Favorite objFavoriteList = _db.favorites.Where(f => f.UserName == currentUser && f.CityName == cityName).FirstOrDefault();
            if (objFavoriteList != null)
            {
                TempData["failed"] = "The city is already in favorites";

                return RedirectToAction("Favorite", new { userName = currentUser });
            }

            Favorite objFavorite = new Favorite();
            objFavorite.CityName = cityName;
            objFavorite.UserName = currentUser;

            _db.favorites.Add(objFavorite);
            _db.SaveChanges();
            TempData["success"] = "Crate is success";

            return RedirectToAction("Favorite", new { userName = currentUser });
        }

        //GET
        public IActionResult DeleteFavorite(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "Delete is failed";
                return NotFound();
            }

            var favoriteFromDb = _db.favorites.Find(id);

            if (favoriteFromDb == null)
            {
                return NotFound();
            }

            return View(favoriteFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFavorite(Favorite obj)
        {
            if (ModelState.IsValid)
            {
                _db.favorites.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Delete is success";
            }

            return RedirectToAction("Favorite", new { userName = currentUser });
        }
    }
}
