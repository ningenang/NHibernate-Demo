namespace DAL.DTO.Classes.Sales
{
	public class SalesTerritory : Entity
	{
		public virtual string Name { get; set; }

		public virtual string Group { get; set; }

		/* Unmapped properties:
		 
			- CountryRegionCode (Person.CountryCode)
			- SalesYTD
			- SalesLastYear
			- CostYTD
			- CostLastYear
		 
		 */
	}
}
