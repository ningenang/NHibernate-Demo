using DAL.DTO.Classes.Person;
using System;

namespace DAL.DTO.Classes.Sales
{
	public class SalesOrderHeader : Entity
	{

		//public virtual SalesOrderDetail SalesOrder { get; set; }

		public virtual DateTime OrderDate { get; set; }

		//public virtual bool OnlineOrderFlag { get; set; }

		public virtual Customer Customer { get; set; }

		public virtual Person.Person SalesPerson { get; set; }

		public virtual SalesTerritory Territory { get; set; }

		public virtual Address BillToAddress { get; set; }

		public virtual Address ShipToAddress { get; set; }


		/* Unmapped properties:
			
			- RevisionNumber
			- DueDate
			- ShipDate
			- Status
			- SalesOrderNumber
			- PurchaseOrderNumber
			- AccountNumber
			- ShipMethod
			- CreditCard
			- CreditCardApprovalCode
			- CurrencyRate
			- SubTotal
			- TaxAmt
			- Freight
			- TotalDue
			- Comment

		 */
	}
}
