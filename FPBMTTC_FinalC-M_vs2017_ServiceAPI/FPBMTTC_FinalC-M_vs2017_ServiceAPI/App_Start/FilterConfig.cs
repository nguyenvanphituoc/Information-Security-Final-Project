using System.Web;
using System.Web.Mvc;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
