using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.DAO;
using NHibernate.Context;

namespace NHibernate_Demo.App_Code
{
	public class ContextualSessionModule : IHttpModule
	{
		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += Context_BeginRequest;
			context.EndRequest += Context_EndRequest;
		}

		private void Context_EndRequest(object sender, EventArgs e)
		{
			var application = (HttpApplication)sender;
			var context = application.Context;

			UnbindSession(context);
		}

		private void Context_BeginRequest(object sender, EventArgs e)
		{
			var application = (HttpApplication)sender;
			var context = application.Context;

			BindSession(context);
		}

		private static void BindSession(HttpContext context)
		{
			var session = SessionFactory.Instance.OpenSession();
			CurrentSessionContext.Bind(session);
		}

		private static void UnbindSession(HttpContext context)
		{
			var session = CurrentSessionContext.Unbind(SessionFactory.GetFactory());

			if (session == null)
				return;

			session.Flush();
			session.Close();
		}

	}
}