using DAL.DAO;
using DAL.DTO.Classes.Sales;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate_Demo.Demo.NPlusOne
{
	public partial class Buggy : System.Web.UI.Page
	{

		public static IEnumerable<object> GetData()
		{
			var session = SessionManager.Instance.CurrentSession;

			var customer = session
				.Query<Customer>()
				.Where(c => c.Person != null)
				.OrderBy(c => c.Id)
				.Take(1000).ToList();

			return customer.Select(c => new
			{
				ID = c.Id,
				LastName = c.Person?.LastName,
				FirstName = c.Person?.FirstName,
				ContactDetails = string.Join(", ", c.Person.Emails.Select(e => e.Address))

			})
			.OrderBy(pc => pc.LastName);
		}

	}
}