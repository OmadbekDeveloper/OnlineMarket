namespace OnlineMarket.Models.Dtos.Employee
{
    public class CreateEmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}
