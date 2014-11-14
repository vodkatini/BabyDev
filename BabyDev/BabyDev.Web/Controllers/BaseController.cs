using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyDev.Data.Contracts;
using BabyDev.Models;
using Microsoft.AspNet.Identity;

namespace BabyDev.Web.Controllers
{
    public class BaseController : Controller
    {

        public BaseController(IBabyDevData data)
        {
            this.Data = data;
        }

        protected IBabyDevData Data { get; set; }

        protected string GetUserId()
        {
            return this.User.Identity.GetUserId();
        }
    }
}