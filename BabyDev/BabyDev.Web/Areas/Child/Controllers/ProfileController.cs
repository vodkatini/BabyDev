using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
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

        public ActionResult Index()
        {
            var userId = this.GetUserId();
            var child = this.Data.Children.All().FirstOrDefault(c => c.ParentId == userId);
            if (child == null)
            {
                return RedirectToAction("Add");
            }

            var childModel = AutoMapper.Mapper.Map<ChildViewModel>(child);
            return View(childModel);
        }

        // GET: Child/Profile
        public ActionResult Related(DateTime born)
        {
            var relatedMonths = (DateTime.Now - born).Days / 30;
            var topics = this.Data.Topics.All().Where(t => t.RelatedMonths == relatedMonths).Project().To<TopicViewModel>();

            //var topicViewModel = new TopicViewModel();

            //if (topic == null)
            //{
            //    topicViewModel.Title = "Your Child is old enough to get a job!";
            //    topicViewModel.Paragraphs = new HashSet<Paragraph>();
            //}
            //else
            //{
            //    topicViewModel.Title = topic.Title;
            //    topicViewModel.Paragraphs = topic.Paragraphs;
            //}

            return PartialView(topics);
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

        public ActionResult Edit()
        {
            var parent = this.GetUserId();
            var userChild = this.Data.Children.All().FirstOrDefault(c => c.ParentId == parent);
            var child = new AddChildViewModel();
            if (userChild != null)
            {
                child.Name = userChild.Name;
                child.Gender = userChild.Gender;
            }
            else
            {
                child.Born = DateTime.Now;
            }

            return View(child);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parentId = this.GetUserId();
                var child = this.Data.Children.All().First(c => c.ParentId == parentId);
                child.Name = model.Name;
                child.Gender = model.Gender;
                
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