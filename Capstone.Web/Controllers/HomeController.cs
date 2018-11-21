using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IParksDAL _parksDAL;

        public HomeController(IParksDAL parksDal)
        {
            _parksDAL = parksDal;
        }


        public IActionResult Index()
        {
            var parks = _parksDAL.GetParks();

            return View(parks);
        }

        public IActionResult ParkDetails(string parkCode)
        {
            var park = _parksDAL.GetPark(parkCode);
            park.Forecasts = _parksDAL.GetWeatherForecasts(park);
            return View(park);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
