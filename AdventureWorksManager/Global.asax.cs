using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace AdventureWorksManager
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ScriptResourceDefinition srd = new ScriptResourceDefinition();
            srd.Path = "~/Scripts/jquery-2.2.3.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",srd);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
          
          
        }


    }
}