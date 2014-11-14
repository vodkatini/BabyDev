using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using AutoMapper.QueryableExtensions;
using BabyDev.Data.Contracts;
using BabyDev.Web.ViewModels;

namespace BabyDev.Web.Controllers
{
    public class CategoryController : SideBarController
    {
        public CategoryController(IBabyDevData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var categories = this.Data.Categories.All()
                .Project()
                .To<CategoryViewModel>()
                .ToList();
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            var category = this.Data.Categories.All()
                .Where(c => c.Id == id)
                .Project()
                .To<CategoryViewModel>()
                .First();
            return View(category);
        }

        public ActionResult _CategoryTopicsPartial(int id)
        {
            var topics = this.Data.Topics
                .All()
                .Where(t => t.CategoryId == id)
                .Project()
                .To<TopicViewModel>()
                .ToList();
            return PartialView(topics);
        }
    }
}