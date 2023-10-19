using OnlineMarket.Models.Dtos.Employee;

namespace OnlineMarket.Interfaces.Models
{
    public interface IEmployeeService
    {
        Task<Responce<IEnumerable<ResultEmployeeDto>>> GetAllEmployeesAsync();
        Task<Responce<ResultEmployeeDto>> GetEmployeeByIdAsync(int id);
        Task<Responce<ResultEmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto employeedto);
        Task<Responce<IEnumerable<ResultEmployeeDto>>> UpdateEmployeeAsync(UpdateEmployeeDto updatedto);
        Task<Responce<bool>> DeleteEmployeeAsync(int id);
    }
}

