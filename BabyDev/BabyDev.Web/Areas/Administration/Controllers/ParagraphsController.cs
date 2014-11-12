using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using BabyDev.Data.Contracts;
using BabyDev.Models;
using BabyDev.Web.Areas.Administration.Controllers.Base;
using BabyDev.Web.Areas.Administration.ViewModels;
using Kendo.Mvc.UI;
using Model = BabyDev.Models.Paragraph;
using ViewModel = BabyDev.Web.Areas.Administration.ViewModels.ParagraphViewModel;

namespace BabyDev.Web.Areas.Administration.Controllers
{
    public class ParagraphsController : KendoGridAdministrationController
    {
        public ParagraphsController(IBabyDevData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            List<Topic> topics = this.Data.Topics.All().ToList();
            ViewBag.TopicsList = topics;
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Paragraphs.All().Project().To<ParagraphViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Paragraphs.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Paragraphs.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}