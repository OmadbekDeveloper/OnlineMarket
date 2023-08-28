namespace OnlineMarket.Interfaces.Models
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(CreateEmployeeDto employeedto);
        Task<bool> UpdateEmployeeAsync(int id, Employee updatedEmployee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}

