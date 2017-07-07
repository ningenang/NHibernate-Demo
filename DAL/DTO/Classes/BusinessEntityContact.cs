namespace DAL.DTO.Classes
{
	public class BusinessEntityContact : Entity
    {
        public virtual Person Person { get; set; }

        public virtual BusinessEntity BusinessEntity { get; set; }

        public virtual ContactType ContactType { get; set; }
    }
}
