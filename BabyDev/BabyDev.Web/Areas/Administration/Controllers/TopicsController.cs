using System.Linq;
using AutoMapper.QueryableExtensions;
using BabyDev.Web.Areas.Administration.ViewModels;
using Kendo.Mvc.Extensions;

namespace BabyDev.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using BabyDev.Data.Contracts;
    using Kendo.Mvc.UI;

    public class TopicsController : AdminController
    {
        // GET: Administration/Admin
        public TopicsController(IBabyDevData data) : base(data)
        {
        }

        public JsonResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data.Topics.All().AsQueryable()
            .Project()
            .To<TopicViewModel>();
            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}