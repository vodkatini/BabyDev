using System.Collections;
using System.Collections.Generic;

namespace BabyDev.Web.Areas.Administration.Controllers
{
    using System;

    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using BabyDev.Models;
    using BabyDev.Data.Contracts;

    using BabyDev.Web.Areas.Administration.ViewModels;
    using BabyDev.Web.Areas.Administration.Controllers.Base;
    using Model = BabyDev.Models.Topic;
    using ViewModel = BabyDev.Web.Areas.Administration.ViewModels.TopicViewModel;

    public class TopicsController : KendoGridAdministrationController
    {
        // GET: Administration/Admin
        public TopicsController(IBabyDevData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            List<Category> categories = this.Data.Categories.All().ToList();
            ViewBag.CategoriesList = categories;
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Topics.All().Project().To<TopicViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Topics.GetById(id) as T;
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
                this.Data.Topics.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

//        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
//        {
//            var result = this.Data.Topics.All()
//                .Project()
//                .To<TopicViewModel>()
//                .ToDataSourceResult(request);
//            return this.Json(result);
//        }

//        [HttpPost]
//        public ActionResult Create([DataSourceRequest]DataSourceRequest request, TopicViewModel model)
//        {
//            if (model != null && this.ModelState.IsValid)
//            {
//                var topic = new Topic();
//                Mapper.Map(model, topic, typeof(TopicViewModel), typeof(Topic));
//                this.Data.Topics.Add(topic);
//                this.Data.SaveChanges();
//            }
//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }
//
//        [HttpPost]
//        public ActionResult Update([DataSourceRequest]DataSourceRequest request, TopicViewModel model)
//        {
//            if (model != null && this.ModelState.IsValid)
//            {
//                var topic = this.Data.Topics.All().FirstOrDefault(t => t.Id == model.Id);
//                Mapper.Map<TopicViewModel, Topic>(model, topic);
//                this.Data.Topics.Update(topic);
//                this.Data.SaveChanges();
//            }
//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }
//
//        [HttpPost]
//        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, TopicViewModel model)
//        {
//            if (model != null)
//            {
//                var topic = this.Data.Topics.All().FirstOrDefault(t => t.Id == model.Id);
//                topic.IsDeleted = true;
//                topic.DeletedOn = DateTime.Now;
//                this.Data.Topics.Update(topic);
//                this.Data.Topics.Delete(topic);
//                this.Data.SaveChanges();
//            }
//            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
//        }
    }
}