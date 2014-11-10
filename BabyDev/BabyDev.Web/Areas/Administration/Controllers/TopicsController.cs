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

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return View();
        }
    }
}