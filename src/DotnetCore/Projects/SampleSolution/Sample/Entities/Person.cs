using System;

namespace CSD.Application.Entities
{
    public enum MaritalStatus { Single, Married, Divorced }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public double Age => (DateTime.Now - BirthDate).TotalDays / 365;
    }
}
