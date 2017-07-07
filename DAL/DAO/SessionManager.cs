using NHibernate;

namespace DAL.DAO
{
	//TODO: RENAME DEFAULT SESSION => CURRENT SESSION
	/// <summary>
	/// Singleton class for managing NHibernate Sessions. The core functionality is the SessionStore Dictionary 
	/// that stores ISessions with a <see cref="Guid"/> key. Methods for managing the sessions are also included.
	/// </summary>
	public class SessionManager
	{
		/// <summary>
		/// Prevents a default instance of the <see cref="SessionManager"/> class from being created.
		/// </summary>
		private SessionManager()
		{
		}

		/// <summary>
		/// Gets the singleton instance.
		/// </summary>
		/// <value>The singleton instance.</value>
		/// <remarks>
		/// This is a thread-safe, lazy singleton. See http://www.yoda.arachsys.com/csharp/singleton.html
		/// for more details about its implementation.
		/// </remarks>
		public static SessionManager Instance => Nested.SessionManager;



		/// <summary>
		/// Gets the default <see cref="ISession"/>.
		/// </summary>
		/// <returns>An <see cref="ISession"/> for quering the data store.</returns>
		public ISession CurrentSession => SessionFactory.GetFactory().GetCurrentSession();



		/// <summary>
		/// Clears the contents of the default session.
		/// </summary>
		public void ClearSession()
		{
			SessionFactory.GetFactory().GetCurrentSession()?.Clear();
		}

		/// <summary>
		/// Disposes the default session.
		/// </summary>
		public void DisposeSession()
		{
			SessionFactory.GetFactory().GetCurrentSession()?.Dispose();
		}


		/// <summary>
		/// Flush the session associated with the given session key.
		/// </summary>
		public void FlushSession()
		{
			SessionFactory.GetFactory().GetCurrentSession()?.Flush();
		}


		/// <summary>
		/// Begins a transaction on the default session.
		/// </summary>
		public void BeginTransaction()
		{
			SessionFactory.GetFactory().GetCurrentSession()?.Transaction?.Begin();
		}

		/// <summary>
		/// Commits the transaction on the default session.
		/// </summary>
		public void CommitTransaction()
		{
			SessionFactory.GetFactory().GetCurrentSession()?.Transaction?.Commit();
		}


		/// <summary>
		/// Rolls back the transaction on the default session.
		/// </summary>
		public void RollbackTransaction()
		{
			SessionFactory.GetFactory().GetCurrentSession()?.Transaction?.Rollback();
		}


		/// <summary>
		/// Determines whether the default session has an open transaction.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if the default session has an open transaction; otherwise, <c>false</c>.
		/// </returns>
		public bool HasOpenTransaction()
		{
			var session = SessionFactory.GetFactory().GetCurrentSession();

			return session?.Transaction?.IsActive ?? false;
		}

		

		/// <summary>
		/// Removes <paramref name="entity"/> from the cache of the default session.
		/// </summary>
		/// <param name="entity">The entity to evict.</param>
		public void Evict(object entity)
		{
			var session = SessionFactory.GetFactory().GetCurrentSession();

			if (session.Contains(entity))
				session.Evict(entity);
		}


		/// <summary>
		/// Re-reads the state of <paramref name="entity"/> from the underlying database using the default session.
		/// </summary>
		/// <param name="entity">The entity to refresh.</param>
		public void Refresh(object entity)
		{
			var session = SessionFactory.GetFactory().GetCurrentSession();

			if (session.Contains(entity))
				session.Refresh(entity);
		}



		/// <summary>
		/// Assists with ensuring thread-safe, lazy singleton
		/// </summary>
		private class Nested
		{
			internal static readonly SessionManager SessionManager = new SessionManager();
		}
	}

}
