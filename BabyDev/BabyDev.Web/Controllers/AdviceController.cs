namespace BabyDev.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using BabyDev.Data.Contracts;
    using BabyDev.Web.ViewModels;
    using BabyDev.Models;

    [Authorize]
    public class AdviceController : SideBarController
    {
        // GET: Advice
        public AdviceController(IBabyDevData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var questions = this.Data.Questions.All()
                .OrderBy(q => q.AskedOn)
                .Project()
                .To<QuestionViewModel>()
                .ToList();
            return View(questions);
        }

        public ActionResult Ask()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ask(AddQuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.GetUserId();
                var question = new Question
                {
                    Title = model.Title,
                    Body = model.Body,
                    AuthorId = userId,
                    AskedOn = DateTime.Now
                };

                this.Data.Questions.Add(question);
                this.Data.SaveChanges();
                return this.RedirectToAction("Details", new { id = question.Id });
            }
            return this.View(model);            
        }

        public ActionResult Details(int id)
        {
            var question = this.Data.Questions.All()
                .Where(q => q.Id == id)
                .Project()
                .To<QuestionViewModel>()
                .First();
            return View(question);
        }
    }
}