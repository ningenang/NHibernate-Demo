using System;

namespace DAL.DTO.Classes.Sales
{
	public class SpecialOffer : Entity
	{
		public virtual string Description { get; set; }

		public virtual decimal DiscountPct { get; set; }

		public virtual string Type { get; set; }

		public virtual string Category { get; set; }

		public virtual DateTime StartDate { get; set; }

		public virtual DateTime EndDate { get; set; }

		public virtual int MinQty { get; set; }

		public virtual int? MaxQty { get; set; }
	}

}
