using DAL.Conventions;
using DAL.DTO.Classes;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Linq;
using System.Reflection;

namespace DAL.DAO
{
	/// <summary>
	/// Singleton class containing the NHibernate SessionFactory. Keeps a single instance of the expensive 
	/// <see cref="ISessionFactory"/> object. Provides methods relevant to SessionFactory usage.
	/// </summary>
	public class SessionFactory
	{
		private ISessionFactory _sessionFactory;

		public static IInterceptor SessionFactoryInterceptor;

		public static event EventHandler<SessionFactoryConfiguringEventArgs> SessionFactoryConfiguring;

		/// <summary>
		/// Prevents a default instance of the <see cref="SessionFactory"/> class from being created.
		/// </summary>
		private SessionFactory()
		{
			Init();
		}

		/// <summary>
		/// Gets the singleton instance.
		/// </summary>
		/// <value>The singleton instance.</value>
		/// <remarks>
		/// This is a thread-safe, lazy singleton. See http://www.yoda.arachsys.com/csharp/singleton.html
		/// for more details about its implementation.
		/// </remarks>
		public static SessionFactory Instance => Nested.SessionFactory;

		/// <summary>
		/// Opens a new session from the NHibernate SessionFactory.
		/// </summary>
		/// <returns>The newly opened session.</returns>
		public ISession OpenSession() => _sessionFactory.OpenSession();


		public static ISessionFactory GetFactory() => Instance._sessionFactory;

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		private void Init()
		{
			try
			{
				var mapper = new DalModelMapper(typeof(Entity));

				mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

				var entities = Assembly.GetExecutingAssembly()
					.GetExportedTypes()
					.Where(t => typeof(Entity).IsAssignableFrom(t) && t != typeof(Entity));

				var mappings = mapper.CompileMappingFor(entities);

				var configuration = new Configuration();

				if (SessionFactoryInterceptor != null)
					configuration.SetInterceptor(SessionFactoryInterceptor);

				configuration.Configure();
				configuration.AddMapping(mappings);

				OnSessionFactoryConfiguring(configuration);
				_sessionFactory = configuration.BuildSessionFactory();
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				while (ex.InnerException != null)
				{
					Console.Error.WriteLine(ex.Message);
					ex = ex.InnerException;
				}
				throw;
			}
		}

		private void OnSessionFactoryConfiguring(Configuration configuration)
		{
			SessionFactoryConfiguring?.Invoke(this, new SessionFactoryConfiguringEventArgs(configuration));
		}


		public class SessionFactoryConfiguringEventArgs : EventArgs
		{
			public Configuration Configuration { get; private set; }

			public SessionFactoryConfiguringEventArgs(Configuration configuration)
			{
				Configuration = configuration;
			}
		}

		

		/// <summary>
		/// Assists with ensuring thread-safe, lazy singleton
		/// </summary>
		private class Nested
		{
			internal static readonly SessionFactory SessionFactory;

			static Nested()
			{
				try
				{
					SessionFactory = new SessionFactory();
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex);
					throw;
				}
			}
		}
	}

}
