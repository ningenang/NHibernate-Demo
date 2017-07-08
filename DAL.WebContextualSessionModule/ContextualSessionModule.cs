using DAL.DAO;
using NHibernate.Context;
using System;
using System.Web;

namespace DAL.WebContextualSessionModule
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
			WebSessionContext.Bind(session);
		}

		private static void UnbindSession(HttpContext context)
		{
			var session = WebSessionContext.Unbind(SessionFactory.GetFactory());

			if (session == null || !session.IsOpen)
				return;

			//if (session.FlushMode == NHibernate.FlushMode.Auto || session.FlushMode == NHibernate.FlushMode.Always)
			//	session.Flush();

			session.Close();
		}

	}
}