using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        ParksDAL dal = new ParksDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True");

        private IParksDAL parksDAL;

        public IActionResult Index()
        {
            var parks = dal.GetParks();

            return View(parks);
        }

        public IActionResult ParkDetails(string parkCode)
        {
            var park = dal.GetPark(parkCode);
            park.Forecasts = dal.GetWeatherForecasts(park);
            return View(park);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
