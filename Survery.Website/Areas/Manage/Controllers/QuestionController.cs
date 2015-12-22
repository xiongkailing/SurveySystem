using MongoDB.Bson;
using Survery.Website.Areas.Manage.Models;
using Survey.Models;
using Survey.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survery.Website.Areas.Manage.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ISurveyTitleService surveyTitleService;
        private readonly IQuestionService questionService;
        public QuestionController(ISurveyTitleService surveyTitleService, IQuestionService questionService)
        {
            this.surveyTitleService = surveyTitleService;
            this.questionService = questionService;
        }
        //
        // GET: /Manage/Question/
        public ActionResult Index(string sId)
        {
            var data=this.questionService.GetQuestionBySurvey(sId);
            List<QuestionViewModel> questions = new List<QuestionViewModel>();
            foreach(var item in data)
            {
                QuestionViewModel dto=new QuestionViewModel();
                dto.MapFromEntity(item);
                questions.Add(dto);
            }
            questions = questions.OrderBy(q => q.SortId).ToList();
            ViewData["SurveyId"] = sId;
            return View(questions);
        }

        public ActionResult Create(string sId)
        {
            var survey = this.surveyTitleService.GetById(sId);
            if (survey == null)
            {
                return HttpNotFound("问卷不存在");
            }
            ViewData["SurveyId"] = sId;
            List<SelectListItem> sls = new List<SelectListItem>();
            sls.Add(new SelectListItem { Text = "SingleSelection", Value = "1" });
            sls.Add(new SelectListItem { Text = "MultipleSelection", Value = "2" });
            sls.Add(new SelectListItem { Text = "QandA", Value = "4" });
            ViewData["QType"] = sls;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Question entity = new Question();
                    entity = viewModel.MapToEntity();
                    this.questionService.CreateQuestion(entity);
                    return Redirect("~/Manage/Question?sId=" + viewModel.SurveryId);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Some Error Happened");
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            List<SelectListItem> sls = new List<SelectListItem>();
            sls.Add(new SelectListItem { Text = "SingleSelection", Value = "1" });
            sls.Add(new SelectListItem { Text = "MultipleSelection", Value = "2" });
            sls.Add(new SelectListItem { Text = "QandA", Value = "4" });
            ViewData["QType"] = sls;
            var data=this.questionService.GetQuestionById(id);
            QuestionViewModel viewModel = new QuestionViewModel();
            viewModel.MapFromEntity(data);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Question entity = new Question();
                    entity = viewModel.MapToEntity();
                    this.questionService.UpdateQuestion(entity);
                    return Redirect("~/Manage/Question/Details/" + viewModel.Id);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Some Error Happened");
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            var data=this.questionService.GetQuestionById(id);
            this.questionService.Delete(id);
            return Redirect("~/Manage/Question?sId=" + data.SurveryId);
        }

        public ActionResult Details (string id)
        {
            var data = this.questionService.GetQuestionById(id);
            QuestionViewModel viewModel = new QuestionViewModel();
            viewModel.MapFromEntity(data);
            return View(viewModel);
        }
    }
}