using System.Collections;
using AutoMapper.QueryableExtensions;
using BabyDev.Data.Contracts;
using BabyDev.Models;
using BabyDev.Web.Areas.Administration.ViewModels;
using Kendo.Mvc.UI;

namespace BabyDev.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BabyDev.Web.Areas.Administration.Controllers.Base;

    public class CategoriesController : KendoGridAdministrationController
    {
        public CategoriesController(IBabyDevData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Categories.All().Project().To<CategoryViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Categories.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            var dbModel = base.Create<Category>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            base.Update<Category, CategoryViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Categories.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}