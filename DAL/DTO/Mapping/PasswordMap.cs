using DAL.DTO.Classes.Person;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class PasswordMap : ClassMapping<Password>
    {
        public PasswordMap()
        {
            Id(pwd => pwd.Id, m => m.Column("BusinessEntityID"));
            ManyToOne(pwd => pwd.Person, m => m.Column("BusinessEntityID"));
        }
    }
}
