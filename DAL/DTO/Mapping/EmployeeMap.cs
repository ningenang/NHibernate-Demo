using DAL.DTO.Classes.HumanResources;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class EmployeeMap : JoinedSubclassMapping<Employee>
    {
        public EmployeeMap()
        {
            Key(km =>
            {
                km.Column("BusinessEntityID");
            });
        }
    }
}
