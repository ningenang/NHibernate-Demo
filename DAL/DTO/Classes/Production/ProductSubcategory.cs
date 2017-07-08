namespace DAL.DTO.Classes.Production
{
	public class ProductSubcategory : Entity
    {
        public virtual string Name { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
