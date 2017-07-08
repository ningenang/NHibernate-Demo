using System;

namespace DAL.DTO.Classes.HumanResources
{
	public class Employee : Person.Person
    {
        public virtual string NationalIDNumber { get; set; }

        public virtual string LoginID { get; set; }

        public virtual string JobTitle { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual char MaritalStatus { get; set; }

        public virtual char Gender { get; set; }

        public virtual DateTime HireDate { get; set; }

        public virtual bool Salaried { get; set; }

        public virtual int VacationHours { get; set; }

        public virtual int SickLeaveHours { get; set; }

        public virtual bool Current { get; set; }
    }
}
