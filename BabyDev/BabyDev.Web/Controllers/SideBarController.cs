using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using BabyDev.Data.Contracts;
using BabyDev.Web.ViewModels;

namespace BabyDev.Web.Controllers
{
    public class SideBarController : BaseController
    {
        // GET: SideBar
        public SideBarController(IBabyDevData data) 
            : base(data)
        {
        }

        [ChildActionOnly]
        public ActionResult _CategoriesPartial()
        {
            var categories = this.Data.Categories.All()
                .OrderBy(c => c.Id)
                .Take(24)
                .Project()
                .To<CategoryViewModel>()
                .ToList();
            return PartialView(categories);
        }

        [ChildActionOnly]
        public ActionResult _QuestionsPartial()
        {
            var topics = this.Data.Questions.All()
                .OrderBy(q => q.AskedOn)
                .Take(10)
                .Project()
                .To<QuestionViewModel>()
                .ToList();
            return PartialView(topics);
        }
    }
}