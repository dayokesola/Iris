using System.Web.Mvc;

namespace IrisManager.Areas.rm
{
    public class rmAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "rm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "rm_default",
                "rm/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}