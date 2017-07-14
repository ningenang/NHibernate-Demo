using DAL.DTO.Classes.Sales;
using System.Collections.Generic;

namespace DAL.DTO.Classes.Person
{
	public class Person : BusinessEntity
    {

		private IEnumerable<Customer> _customers = new List<Customer>();

        public virtual string PersonType { get; set; }

        public virtual NameStyle NameStyle { get; set; }

        public virtual string Title { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Suffix { get; set; }

        public virtual int EmailPromotion { get; set; }

        public virtual Password Password { get; set; }

		public virtual IEnumerable<Customer> Customers => _customers;

	}
}
