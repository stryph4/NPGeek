using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {

        SurveyDAL dal = new SurveyDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True");


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SurveyResult surveyResult)
        {
            if (ModelState.IsValid)
            {
                dal.SaveNewSurveyResult(surveyResult);
                

                return RedirectToAction("surveyresults");
            }
            return View("index");
        }

        public IActionResult SurveyResults()
        {
            var results = dal.GetSurveyResults();
            return View(results);
        }

    }
}
