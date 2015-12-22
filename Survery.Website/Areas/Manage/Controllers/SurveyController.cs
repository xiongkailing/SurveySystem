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
    public class SurveyController : Controller
    {
        private readonly ISurveyTitleService surveyService;
        public SurveyController(ISurveyTitleService surveyService)
        {
            this.surveyService = surveyService;
        }

        public ActionResult Index()
        {
            var entitys = this.surveyService.GetAllSurvery();
            List<SurveyTitleViewModel> viewModels = new List<SurveyTitleViewModel>();
            foreach (var item in entitys)
            {
                SurveyTitleViewModel dto = new SurveyTitleViewModel();
                dto.MapFromEntity(item);
                viewModels.Add(dto);
            }
            return View(viewModels);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyTitleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SurveyTitle st = viewModel.MapToEntity();
                this.surveyService.CreateSurvey(st);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Some Error hanppend");
            }
            return View();
        }
        public ActionResult Details(string id)
        {
            var data=this.surveyService.GetById(id);
            if (data == null)
            {
                return new HttpNotFoundResult("该资源未找到");
            }
            SurveyTitleViewModel viewModel = new SurveyTitleViewModel();
            viewModel.MapFromEntity(data);
            return View(viewModel);
        }

        public ActionResult Delete(string id)
        {
            this.surveyService.DeleteById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var data = this.surveyService.GetById(id);
            if (data == null)
            {
                return new HttpNotFoundResult("该资源未找到");
            }
            SurveyTitleViewModel viewModel = new SurveyTitleViewModel();
            viewModel.MapFromEntity(data);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SurveyTitleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SurveyTitle st = viewModel.MapToEntity();
                this.surveyService.UpdateSurvey(st);
                return RedirectToAction("Details",viewModel);
            }
            else
            {
                ModelState.AddModelError("", "Some Error hanppend");
            }
            return View();
        }
    }
}