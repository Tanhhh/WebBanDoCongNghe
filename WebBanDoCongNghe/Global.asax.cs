using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebBanDoCongNghe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["visit"] = 0;
            Application["Online"] = 0;
        }
        protected void Session_Start()
        {
            Application.Lock();
            Application["visit"] = (int)Application["visit"] + 1;
            Application["Online"] = (int)Application["Online"] + 1;
            Application.UnLock();
        }
        protected void Session_end()
        {
            Application.Lock();
            Application["Online"] = (int)Application["Online"] - 1;
            Application.UnLock();
        }
    }
}
