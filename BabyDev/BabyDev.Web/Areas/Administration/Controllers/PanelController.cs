using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyDev.Data.Contracts;

namespace BabyDev.Web.Areas.Administration.Controllers
{
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
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult Paragraphs()
        {
            return View();
        }
    }
}