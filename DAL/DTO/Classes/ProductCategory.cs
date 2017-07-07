using System.Collections.Generic;

namespace DAL.DTO.Classes
{
	public class ProductCategory : Entity
    {
        private IList<ProductSubcategory> _subcategories = new List<ProductSubcategory>();

        public virtual string Name { get; set; }

		public virtual IEnumerable<ProductSubcategory> Subcategories => _subcategories;
	}
}
