using System.Collections.Generic;

namespace DAL.DTO.Classes
{
	public abstract class BusinessEntity : Entity
    {
        protected IList<BusinessEntityAddress> _addresses = new List<BusinessEntityAddress>();
        protected IList<BusinessEntityContact> _contacts = new List<BusinessEntityContact>();

		public virtual IEnumerable<BusinessEntityAddress> Addresses => _addresses;
		public virtual IEnumerable<BusinessEntityContact> Contacts => _contacts;
	}
}
