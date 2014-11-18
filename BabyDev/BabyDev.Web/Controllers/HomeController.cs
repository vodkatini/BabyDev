namespace BabyDev.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using BabyDev.Data.Contracts;
    using BabyDev.Models;
    using BabyDev.Web.ViewModels;

    public class HomeController : SideBarController
    {
        public HomeController(IBabyDevData data) 
            : base(data)
        {
        }
        
        public ActionResult Index()
        {
            var topics = this.Data.Topics.All()
                .OrderByDescending(t => t.CreatedOn)
                .Project()
                .To<TopicViewModel>()
                .Take(4)
                .ToList();
            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us";

            return View();
        }
//
//        public ActionResult Topic(int id)
//        {
//            var topic = this.Data.Topics.All()
//                .Project()
//                .To<TopicViewModel>()
//                .First(t => t.Id == id);
//            return View(topic);
//        }
//
//        public ActionResult Category(int id)
//        {
//            var topic = this.Data.Categories.All()
//                .Project()
//                .To<CategoryViewModel>()
//                .First(t => t.Id == id);
//            return View(topic);
//        }

        public ActionResult Error()
        {
            return View();
        }
    }
}