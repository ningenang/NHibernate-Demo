using System;

namespace DAL.DTO.Classes.Production
{
	public class WorkOrder : Entity
	{
		public virtual Product Product { get; set; }

		public virtual int OrderQty { get; set; }

		public virtual int ScrappedQty { get; set; }

		public virtual DateTime StartDate { get; set; }

		public virtual DateTime? EndDate { get; set; }

		public virtual DateTime DueDate { get; set; }

	}
}
