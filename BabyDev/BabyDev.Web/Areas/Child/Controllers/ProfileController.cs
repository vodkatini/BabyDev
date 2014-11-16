using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyDev.Data.Contracts;
using BabyDev.Models;
using BabyDev.Web.Controllers;
using BabyDev.Web.Areas.Child.ViewModels;
using Microsoft.AspNet.Identity;

namespace BabyDev.Web.Areas.Child.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(IBabyDevData data) 
            : base(data)
        {
        }
        // GET: Child/Profile
        public ActionResult Index(int? relatedMonths)
        {
            var userId = this.GetUserId();
            var child = this.Data.Children.All().FirstOrDefault(c => c.ParentId == userId);
            if (child == null)
            {
                    return RedirectToAction("Add");               
            }

            if (relatedMonths == null)
            {
                relatedMonths = (DateTime.Now - child.Born).Days / 30;
            }

            var topic = this.Data.Topics.All().FirstOrDefault(t => t.RelatedMonths == relatedMonths);

            var topicViewModel = new TopicViewModel();

            if (topic == null)
            {
                topicViewModel.Title = "Your Child is old enough to get a job!";
                topicViewModel.Paragraphs = new HashSet<Paragraph>();
            }
            else
            {
                topicViewModel.Title = topic.Title;
                topicViewModel.Paragraphs = topic.Paragraphs;
            }

            return View(topicViewModel);
        }

        public ActionResult Add()
        {
            var child = new AddChildViewModel();
            child.Born = DateTime.Now;
            return View(child);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                var child = new Models.Child()
                {
                    Name = model.Name,
                    Born = model.Born == null ? DateTime.Now : DateTime.Parse(model.Born.ToString()),
                    Gender = model.Gender,
                    ParentId = this.User.Identity.GetUserId()
                };
                this.Data.Children.Add(child);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            TempData["success"] = model.Name + " was successfully added";
            return View(model);
        }

        public ActionResult Prev(int id)
        {
            //var current = this.Data.Topics.All().First(t => t.Id == id).RelatedMonths;
            return RedirectToAction("Index", new { relatedMonths = id - 1 });
        }

        public ActionResult Next(int id)
        {
            //var current = this.Data.Topics.All().First(t => t.Id == id).RelatedMonths;
            return RedirectToAction("Index", new { relatedMonths = id + 1 });
        }
    }
}