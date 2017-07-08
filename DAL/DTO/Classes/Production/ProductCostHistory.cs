using System;

namespace DAL.DTO.Classes.Production
{

	public class ProductCostHistory : Entity
    {
        public virtual Product Product { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual decimal StandardCost { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var history = obj as ProductCostHistory;

            if (obj == null)
            {
                return false;
            }

            return history.StartDate == StartDate &&
                history.Product == Product;
        }

        public override int GetHashCode()
        {
            return (StartDate.Ticks.ToString() + "|" + Product.Id.ToString()).GetHashCode();
        }
    }
}
