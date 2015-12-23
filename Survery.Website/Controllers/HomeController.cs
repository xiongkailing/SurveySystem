using Survey.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survery.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISurveyTitleService surveyService;
        public HomeController(ISurveyTitleService surveyService)
        {
            this.surveyService = surveyService;
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var survey = this.surveyService.GetAllSurvery().FirstOrDefault();
            ViewData["SurveyId"] = survey._id.ToString();
            return View();
        }
	}
}