using DAL.DTO.Classes.Person;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class EmailAddressMap : ClassMapping<EmailAddress>
	{
		public EmailAddressMap()
		{
			ComponentAsId(p => p.Id, m =>
			{
				m.ManyToOne(id => id.BusinessEntity);
				m.Property(id => id.EmailAddressID);
			});

			Property(p => p.Address, m => m.Column("EmailAddress"));
		}
	}
}
