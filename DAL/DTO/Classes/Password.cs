﻿namespace DAL.DTO.Classes
{

	public class Password : Entity
    {
        public virtual Person Person { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string PasswordSalt { get; set; }
    }
}
