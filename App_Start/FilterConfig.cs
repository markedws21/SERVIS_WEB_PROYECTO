using System.Web;
using System.Web.Mvc;

namespace SERVIS_WEB_PROYECTO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
