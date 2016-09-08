using System.Web.Mvc;

namespace IrisManager.Areas.gl
{
    public class glAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "gl";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "gl_default",
                "gl/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}