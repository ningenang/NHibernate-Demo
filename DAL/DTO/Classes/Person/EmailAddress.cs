namespace DAL.DTO.Classes.Person
{
	public class EmailAddress : Entity
	{

		public virtual EmailAddressId Id { get; set; }

		public virtual string Address { get; set; }
	}

	public class EmailAddressId
	{
		public virtual BusinessEntity BusinessEntity { get; set; }

		public virtual int EmailAddressID { get; set; }


		public override int GetHashCode()
		{
			return BusinessEntity.GetHashCode() ^ EmailAddressID.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var otherId = obj as EmailAddressId;

			if (otherId == null)
			{
				return false;
			}

			return BusinessEntity.Equals(otherId.BusinessEntity) &&
				EmailAddressID.Equals(otherId.EmailAddressID);
				
		}
	}
}
