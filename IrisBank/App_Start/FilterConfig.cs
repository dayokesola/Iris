using com.iris.Web;
using System.Web;
using System.Web.Mvc;

namespace IrisBank
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new IrisFilter());
        }
    }
}
