using HibernatingRhinos.Profiler.Appender.NHibernate;
using log4net;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace NHibernate_Demo
{
	public class Global : HttpApplication
	{
		private static readonly ILog log = LogManager.GetLogger(nameof(Global));

		void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			log4net.Config.XmlConfigurator.Configure();
			NHibernateProfiler.Initialize();
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			Context.Items.Add("RequestStartTime", DateTime.Now);
		}


		protected void Application_EndRequest(Object sender, EventArgs e)
		{
			var tsDuration = DateTime.Now.Subtract((DateTime)Context.Items["RequestStartTime"]);
			log.Debug($"{Request.RawUrl}: {tsDuration.Milliseconds} ms");
		}
	}
}