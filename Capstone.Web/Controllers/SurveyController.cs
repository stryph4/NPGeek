using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {

        SurveyDAL dal = new SurveyDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True");

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SurveyResults()
        {
            var results = dal.GetSurveyResults();
            return View(results);
        }

    }
}
