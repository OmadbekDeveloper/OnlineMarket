using OnlineMarket.Models.Dtos;
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
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await employeeService.GetAllEmployeesAsync();
            if (employees == null)
                return NotFound();

            return Ok(employees);
        } // done

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        } // done

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employeedto)
        {
            await employeeService.CreateEmployeeAsync(employeedto);

            return Ok("Created");
        } // done

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            var updateemployee = employeeService.UpdateEmployeeAsync(id, updatedEmployee);
            if (updateemployee == null)
                return NotFound();

            return Ok(updateemployee);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleteemployee = employeeService.DeleteEmployeeAsync(id);
            if (deleteemployee == null)
                return NotFound();

            return Ok(deleteemployee);
        }
    }
}