using DAL.DAO;
using DAL.DTO.Classes.Person;
using DAL.DTO.Classes.Production;
using DAL.DTO.Classes.Sales;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace NHibernate_Demo.Demo.NPlusOne
{
	public partial class Buggy : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		public static IEnumerable<object> GetSalesTransactions()
		{
			var session = SessionManager.Instance.CurrentSession;


			var persons = session.Query<Person>()
				.Fetch(p => p.Password) //Trenger denne for å unngå en ekstra select for å hente passord
				.FirstOrDefault();




			var mostSoldProducts = session.Query<Product>()
				.OrderByDescending(p => p.TransactionHistory.Where(th => th.TransactionType == 'S').Count())
				.Take(10)
				.ToList();

			return mostSoldProducts.Select(msp => 
			{
				var returnValue = new
				{
					Name = msp.Name,
					TransactionCount = msp.TransactionHistory.Count()
				};


				//var so = session.Query<SalesOrderDetail>().ToList();

				var salesOrders =
					session.Query<SalesOrderDetail>()
					.Fetch(sod => sod.Id)
					.Where(sod => sod.Product.Id == msp.Id)

					.ToList();


				return returnValue;
			}
			);
		}
	}
}