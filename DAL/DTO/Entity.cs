using System;

namespace DAL.DTO.Classes
{

	public abstract class Entity
	{
		public virtual int Id { get; set; }

		public virtual DateTime ModifiedDate { get; set; }

		public override int GetHashCode() => Id.GetHashCode();

		public override bool Equals(object obj)
		{
			var o = obj as Entity;

			if (o == null)
				return false;

			return o.Id == Id;
		}
	}
}
