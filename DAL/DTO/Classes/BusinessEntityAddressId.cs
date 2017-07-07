namespace DAL.DTO.Classes
{

	public class BusinessEntityAddressId
    {
        public virtual BusinessEntity BusinessEntity { get; set; }

        public virtual Address Address { get; set; }

        public virtual AddressType AddressType { get; set; }

        public override int GetHashCode()
        {
            return BusinessEntity.GetHashCode() ^ AddressType.GetHashCode() ^ Address.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherId = obj as BusinessEntityAddressId;

            if (otherId == null)
            {
                return false;
            }

            return Address.Equals(otherId.Address) &&
                AddressType.Equals(otherId.AddressType) &&
                BusinessEntity.Equals(otherId.BusinessEntity);
        }
    }
}
