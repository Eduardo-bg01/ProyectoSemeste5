using System.Web;
using System.Web.Mvc;

namespace SAPROC_RanchoNuevo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerifySession());
        }
    }
}
