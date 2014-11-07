using BabyDev.Models;
using BabyDev.Web.ViewModels;

namespace BabyDev.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using BabyDev.Data.Contracts;
    

    using AutoMapper.QueryableExtensions;

    public class HomeController : BaseController
    {
        public HomeController(IBabyDevData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var topics = this.Data.Topics.All()
                .Project()
                .To<TopicViewModel>()
                .Take(5)
                .ToList();
            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}