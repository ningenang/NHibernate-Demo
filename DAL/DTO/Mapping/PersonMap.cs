using DAL.DTO.Classes;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class PersonMap : ClassMapping<Person>
    {
        public PersonMap()
        {
            OneToOne(p => p.Password, m =>
            {
                m.Cascade(NHibernate.Mapping.ByCode.Cascade.All);
            });
        }
    }
}
