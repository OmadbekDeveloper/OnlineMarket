namespace OnlineMarket.Interfaces.Models
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(int id, Employee updatedEmployee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}

