using System;

namespace DAL.DTO.Classes
{
	public class ProductReview : Entity
    {
        public virtual Product Product { get; set; }

        public virtual string ReviewerName { get; set; }

        public virtual DateTime ReviewDate { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual int Rating { get; set; }

        public virtual string Comments { get; set; }
    }
}
