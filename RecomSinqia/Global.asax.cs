using RecomSinqia.AcessoDados;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RecomSinqia
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

			// Database.SetInitializer<RecomSinqiaContexto>(null);		
			//Database.SetInitializer<RecomSinqiaContexto>(new DropCreateDatabaseIfModelChanges<RecomSinqiaContexto>());
			Database.SetInitializer<RecomSinqiaContexto>(new RecomSinqiaInit());
		}
	}
}
