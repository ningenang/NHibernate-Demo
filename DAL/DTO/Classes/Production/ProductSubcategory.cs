using System.Collections.Generic;

namespace DAL.DTO.Classes.Production
{
	public class ProductSubcategory : Entity
    {
		private IList<Product> _products = new List<Product>();

		public virtual string Name { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

		public virtual IEnumerable<Product> Products => _products;
    }
}
