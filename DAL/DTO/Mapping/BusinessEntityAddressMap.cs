using DAL.DTO.Classes;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class BusinessEntityAddressMap : ClassMapping<BusinessEntityAddress>
    {
        public BusinessEntityAddressMap()
        {
            ComponentAsId(p => p.Id, m =>
            {
                m.ManyToOne(id => id.Address);
                m.ManyToOne(id => id.AddressType);
                m.ManyToOne(id => id.BusinessEntity);
            });
        }
    }
}
