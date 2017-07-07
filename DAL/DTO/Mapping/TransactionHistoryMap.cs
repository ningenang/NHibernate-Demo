using DAL.DTO.Classes;
using NHibernate.Mapping.ByCode.Conformist;

namespace DAL.DTO.Mapping
{
	public class TransactionHistoryMap : ClassMapping<TransactionHistory>
    {
        public TransactionHistoryMap()
        {
            Id(tx => tx.Id, m => m.Column("TransactionID"));
        }
    }
}
