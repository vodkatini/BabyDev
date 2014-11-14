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
        public ActionResult _TopicsPartial()
        {
            var topics = this.Data.Topics.All()
                .OrderBy(t => t.Title)
                .Take(24)
                .Project()
                .To<TopicViewModel>()
                .ToList();
            return PartialView(topics);
        }
    }
}