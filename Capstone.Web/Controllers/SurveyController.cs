using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL _dal;

        public SurveyController(ISurveyDAL dal)
        {
            _dal = dal;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SurveyResult surveyResult)
        {
            if (!ModelState.IsValid) return BadRequest("An error has occured while processing your request.");
            _dal.SaveNewSurveyResult(surveyResult);
            return RedirectToAction("surveyresults");
        }

        public IActionResult SurveyResults()
        {
            var results = _dal.GetSurveyResults();
            return View(results);
        }

    }
}
