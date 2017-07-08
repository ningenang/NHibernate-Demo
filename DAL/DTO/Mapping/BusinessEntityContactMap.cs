using DAL.DTO.Classes.Person;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class BusinessEntityContactMap : ClassMapping<BusinessEntityContact>
    {
        public BusinessEntityContactMap()
        {
            ComposedId(id =>
            {
                id.ManyToOne(m => m.BusinessEntity);
                id.ManyToOne(m => m.ContactType);
                id.ManyToOne(m => m.Person);
            });
        }
    }
}
