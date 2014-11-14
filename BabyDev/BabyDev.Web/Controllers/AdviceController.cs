using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyDev.Data.Contracts;

namespace BabyDev.Web.Controllers
{
    [Authorize]
    public class AdviceController : BaseController
    {
        // GET: Advice
        public AdviceController(IBabyDevData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ask()
        {
            return RedirectToAction("Question");
        }

        public ActionResult Question(int id)
        {
            return View();
        }
    }
}