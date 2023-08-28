using OnlineMarket.Interfaces.Person;

namespace OnlineMarket.Models.Models
{
    public class Customer : IPerson
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
