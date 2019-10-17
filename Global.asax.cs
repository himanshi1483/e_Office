using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace e_Office
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("X-Frame-Options");
            Response.AddHeader("X-Frame-Options", "SAMEORIGIN");

        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           // DocuViewareLicensing.RegisterKEY("028752749286424d9fa97995913964d88944418b08bf43a4Gx4ZcGz7zE8pzwYyLtCWhhqcW/TElpE8vdNooePcDI5/eFimqlbgw4626xZ5akP8"); //Unlocking DocuVieware
           // DocuViewareManager.SetupConfiguration(true, DocuViewareSessionStateMode.InProc, HttpRuntime.AppDomainAppPath + "\\Documents\\Cache");
        }
    }
}
