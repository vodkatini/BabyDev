using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyDev.Data.Contracts;
using BabyDev.Models;
using BabyDev.Web.Areas.Child.ViewModels;
using BabyDev.Web.Controllers;
using BabyDev.Web.ViewModels;
using Microsoft.AspNet.Identity;

namespace BabyDev.Web.Areas.Child.Controllers
{
    public class ProfileController : BaseController
    {
        public ProfileController(IBabyDevData data) 
            : base(data)
        {
        }
        // GET: Child/Profile
        public ActionResult Index()
        {
            if (TempData["success"] != null)
            {
                return View(TempData["success"]);
            }

            var userId = this.User.Identity.GetUserId();
            var child = this.Data.Children.All().FirstOrDefault(c => c.ParentId == userId);
            if (child == null)
            {
                return RedirectToAction("Add");
            }
            var relatedMonths = (DateTime.Now - child.Born).Days/30;
            var topic = this.Data.Topics.All().First(t => t.RelatedMonths == relatedMonths);

            var topicViewModel = new TopicViewModel()
            {
                Title = topic.Title,
                Paragraphs = topic.Paragraphs
            };

            var childViewModel = new ChildViewModel()
            {
                Name = child.Name,
                Born = child.Born,
                Gender = child.Gender
            };

            return View(topicViewModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                var child = new Models.Child()
                {
                    Name = model.Name,
                    Born = model.Born,
                    Gender = model.Gender,
                    ParentId = this.User.Identity.GetUserId()
                };
                this.Data.Children.Add(child);
                this.Data.SaveChanges();
            }
            TempData["success"] = model.Name + " was successfully added";
            return RedirectToAction("Index");
        }
    }
}