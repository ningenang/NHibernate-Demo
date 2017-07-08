using DAL.DTO.Classes.Production;

namespace DAL.DTO.Classes.Sales
{
	public class SalesOrderDetail : Entity
	{
		public virtual SalesOrderDetailId Id { get;set; }

		public virtual string CarrierTrackingNumber { get; set; }

		public virtual int OrderQty { get; set; }

		public virtual Product Product { get; set; }

		public virtual SpecialOffer SpecialOffer { get; set; }

		public virtual decimal UnitPrice { get; set; }

		public virtual decimal UnitPriceDiscount { get; set; }
	}


	public class SalesOrderDetailId
	{
		public virtual SalesOrderHeader SalesOrder { get; set; }

		public virtual int SalesOrderDetailID { get; set; }

		public override int GetHashCode()
		{
			return SalesOrder.GetHashCode() ^ SalesOrderDetailID.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var otherId = obj as SalesOrderDetailId;

			if (otherId == null)
				return false;

			return SalesOrder.Equals(otherId.SalesOrder) && 
				SalesOrderDetailID.Equals(otherId.SalesOrderDetailID);
		}
	}
}
