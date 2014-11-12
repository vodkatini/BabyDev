namespace BabyDev.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using BabyDev.Models;
    using BabyDev.Data.Contracts;

    using BabyDev.Web.Areas.Administration.ViewModels;


    public class TopicsController : AdminController
    {
        // GET: Administration/Admin
        public TopicsController(IBabyDevData data) : base(data)
        {
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data.Topics.All()
                .Project()
                .To<TopicViewModel>()
                .ToDataSourceResult(request);
            return this.Json(result);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, TopicViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var topic = new Topic();
                Mapper.Map(model, topic, typeof(TopicViewModel), typeof(Topic));
                this.Data.Topics.Add(topic);
                this.Data.SaveChanges();
            }
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, TopicViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var topic = this.Data.Topics.All().FirstOrDefault(t => t.Id == model.Id);
                Mapper.Map(model, topic, typeof(TopicViewModel), typeof(Topic));
                this.Data.Topics.Update(topic);
                this.Data.SaveChanges();
            }
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, TopicViewModel model)
        {
            if (model != null)
            {
                var topic = this.Data.Topics.All().FirstOrDefault(t => t.Id == model.Id);
//                topic.Deleted = true;
//                topic.DeletedOn = DateTime.Now;
//                this.Data.Topics.Update(topic);
                this.Data.Topics.Delete(topic);
                this.Data.SaveChanges();
            }
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}