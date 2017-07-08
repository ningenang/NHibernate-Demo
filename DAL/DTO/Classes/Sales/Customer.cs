namespace DAL.DTO.Classes.Sales
{
	public class Customer : Entity
	{
		public virtual Person.Person Person { get; set; }

		public virtual Store Store { get; set; }

		public virtual SalesTerritory Territory { get; set; }

		/* Unmapped properties:
			- AccountNumber
		 */
	}
}
