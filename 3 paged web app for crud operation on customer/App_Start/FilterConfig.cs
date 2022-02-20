using System.Web;
using System.Web.Mvc;

namespace _3_paged_web_app_for_crud_operation_on_customer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
