using DAL.DTO.Classes.Production;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class ProductCostHistoryMap : ClassMapping<ProductCostHistory>
    {
        public ProductCostHistoryMap()
        {
            ComposedId(opt =>
            {
                opt.Property(pch => pch.StartDate);
                opt.ManyToOne(pch => pch.Product);
            });
        }
    }
}
