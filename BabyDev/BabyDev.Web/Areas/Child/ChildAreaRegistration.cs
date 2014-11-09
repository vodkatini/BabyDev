using System.Web.Mvc;

namespace BabyDev.Web.Areas.Child
{
    public class ChildAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Child";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Child_default",
                "Child/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}