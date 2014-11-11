using System.Data.Entity;

namespace BabyDev.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;

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
    }
}