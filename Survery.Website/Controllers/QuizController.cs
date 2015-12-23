using Survery.Website.Areas.Manage.Models;
using Survey.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survery.Website.Controllers
{
    public class QuizController : Controller
    {
        private readonly ISurveyTitleService surveyService;
        private readonly IQuestionService questionService;
        public QuizController(ISurveyTitleService surveyService,IQuestionService questionService)
        {
            this.surveyService = surveyService;
            this.questionService = questionService;
        }
        //
        // GET: /Survey/
        public ActionResult Index(string sId)
        {
            var survey = this.surveyService.GetById(sId);
            ViewData["SurveyName"] = survey.Name;
            var questions=this.questionService.GetQuestionBySurvey(sId);
            List<QuestionViewModel> viewModels = new List<QuestionViewModel>();
            foreach (var item in questions)
            {
                QuestionViewModel qv = new QuestionViewModel();
                qv.MapFromEntity(item);
                viewModels.Add(qv);
            }
            return View(viewModels);
        }
	}
}