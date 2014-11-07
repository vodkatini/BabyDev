using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyDev.Data.Contracts;
using BabyDev.Models;

namespace BabyDev.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public BaseController(IBabyDevData data)
        {
            this.Data = data;
        }

        public BaseController(IBabyDevData data, BabyDevUser user)
            : this(data)
        {
            this.UserProfile = user;
        }

        protected IBabyDevData Data { get; set; }

        protected BabyDevUser UserProfile { get; set; }
    }
}