using DAL.DAO;
using DAL.DTO.Classes.Person;
using DAL.DTO.Classes.Sales;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NHibernate_Demo.Demo.NPlusOne
{
	public partial class Fixed : System.Web.UI.Page
	{
		private Stopwatch _stopWatch = new Stopwatch();

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public static IEnumerable<object> GetData()
		{
			var session = SessionManager.Instance.CurrentSession;

			var customer = session.Query<Customer>()
				.Where(c => c.Person != null)
				.OrderBy(c => c.Id)
				.Take(1000)
				.ToList();

			var fetchQuery = session.Query<Customer>()
				.Fetch(c => c.Person)
				.ThenFetch(p => p.Password)
				.Where(c => customer.Contains(c))
				.ToFuture();

			session.Query<Person>()
				.Fetch(p => p.Emails)
				.Where(p => p.Customers.Any(c => customer.Contains(c)))
				.ToFuture();

			fetchQuery.ToList();

			return customer.
				Select(c => new
				{
					ID = c.Id,
					LastName = c.Person?.LastName,
					FirstName = c.Person?.FirstName,
					ContactDetails = string.Join(", ", c.Person.Emails.Select(e => e.Address))

				})
			.OrderBy(pc => pc.LastName);
		}

		protected void odsData_Selecting(object sender, System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs e)
		{
			_stopWatch.Restart();
		}

		protected void odsData_Selected(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
		{
			lblDiagnostic.Text = _stopWatch.Elapsed.ToString();
		}
	}
}