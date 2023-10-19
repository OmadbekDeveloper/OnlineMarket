using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos.Employee;
using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("GetEmployees")]
        public async Task<Responce<IEnumerable<ResultEmployeeDto>>> GetEmployees()
        {
            var employees = await employeeService.GetAllEmployeesAsync();

            return employees;
        } // done

        [HttpGet("GetEmployee")]
        public async Task<Responce<ResultEmployeeDto>> GetEmployee(int id)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);

            return employee;
        } // done

        [HttpPost("CreateEmployee")]
        public async Task<Responce<ResultEmployeeDto>> CreateEmployee(CreateEmployeeDto employeedto)
        {
            var employee = await employeeService.CreateEmployeeAsync(employeedto);

            return employee;
        } // done

        [HttpPut("UpdateEmployee")]
        public async Task<Responce<IEnumerable<ResultEmployeeDto>>> UpdateEmployee(UpdateEmployeeDto updatedto)
        {
            var employee = await employeeService.UpdateEmployeeAsync(updatedto);

            return employee;
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<Responce<bool>> DeleteEmployee(int id)
        {
            var employee = await employeeService.DeleteEmployeeAsync(id);

            return employee;
        }
    }
}