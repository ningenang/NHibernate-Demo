using DAL.DTO.Classes.Sales;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class SalesOrderDetailMap : ClassMapping<SalesOrderDetail>
	{
		public SalesOrderDetailMap()
		{
			
			ComponentAsId(sod => sod.Id, m =>
			{
				m.Property(id => id.SalesOrderDetailID);
				m.ManyToOne(id => id.SalesOrder);
			});


		}

	}
}
