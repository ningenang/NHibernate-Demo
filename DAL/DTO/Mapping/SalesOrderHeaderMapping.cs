using DAL.DTO.Classes.Sales;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class SalesOrderHeaderMapping : ClassMapping<SalesOrderHeader>
	{
		public SalesOrderHeaderMapping()
		{
			Id(soh => soh.Id, m => m.Column("SalesOrderID"));

			//ManyToOne(soh => soh.SalesOrder, m => m.Column("SalesOrderID"));
		}
	}
}
