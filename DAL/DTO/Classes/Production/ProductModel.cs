namespace DAL.DTO.Classes.Production
{
	public class ProductModel : Entity
    {
        public virtual string Name { get; set; }

        public virtual string CatalogDescription { get; set; }

        public virtual string Instructions { get; set; }
    }
}
