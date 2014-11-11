namespace BabyDev.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using BabyDev.Web.Controllers;

    using BabyDev.Data.Contracts;
    using BabyDev.Models;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        // GET: Administration/Admin
        protected AdminController(IBabyDevData data) : base(data)
        {
        }
    }
}