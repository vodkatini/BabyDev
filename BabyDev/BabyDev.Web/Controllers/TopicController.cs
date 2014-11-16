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
    public class TopicController : SideBarController
    {
        public TopicController(IBabyDevData data) : base(data)
        {
        }

        public ActionResult Index(int page)
        {            
            var topics = this.Data.Topics
                .All()
                .OrderBy(t => t.RelatedMonths)
                .Skip(page)
                .Take(5)
                .Project()
                .To<TopicViewModel>()
                .ToList();
            return View(topics);
        }

        public ActionResult Details(int id)
        {
            var topic = this.Data.Topics.All()
                .Where(t => t.Id == id)
                .Project()
                .To<TopicViewModel>()
                .First();
            return View(topic);
        }
    }
}