using System;

namespace BusinessModels
{
    public class Employee
    {
        public Employee()
        {
            this.IsDeleted = false;
            this.CreatedDate = DateTime.UtcNow;
        }
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
