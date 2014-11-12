


namespace BabyDev.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BabyDev.Data.Contracts;

    using BabyDev.Web.Areas.Administration.Controllers.Base;

    public class PanelController : AdminController
    {
        // GET: Administration/Panel
        public PanelController(IBabyDevData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Topics()
        {
            return RedirectToAction("Index", "Topics");
        }

        public ActionResult Categories()
        {
            return RedirectToAction("Index", "Categories");
        }

        public ActionResult Paragraphs()
        {
            return RedirectToAction("Index", "Paragraphs");
        }
    }
}