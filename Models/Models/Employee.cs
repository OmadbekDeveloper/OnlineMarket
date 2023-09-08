using OnlineMarket.Interfaces.Person;

namespace OnlineMarket.Models.Models
{
    public class Employee : IPerson
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
