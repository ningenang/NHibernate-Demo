using System.Collections.Generic;

namespace DAL.DTO.Classes.Person
{
	public abstract class BusinessEntity : Entity
    {
        protected IList<BusinessEntityAddress> _addresses = new List<BusinessEntityAddress>();
        protected IList<BusinessEntityContact> _contacts = new List<BusinessEntityContact>();
		protected IList<EmailAddress> _emails = new List<EmailAddress>();

		public virtual IEnumerable<BusinessEntityAddress> Addresses => _addresses;
		public virtual IEnumerable<BusinessEntityContact> Contacts => _contacts;

		public virtual IEnumerable<EmailAddress> Emails => _emails;
	}
}
