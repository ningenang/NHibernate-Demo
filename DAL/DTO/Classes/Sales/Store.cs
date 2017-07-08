using DAL.DTO.Classes.Person;

namespace DAL.DTO.Classes.Sales
{
	public class Store : BusinessEntity
	{
		public virtual string Name { get; set; }

		public virtual Person.Person SalesPerson { get; set; }
	}
}
