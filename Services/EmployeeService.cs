// DONE
public class EmployeeService : IEmployeeService
{
    private readonly OnlineMarketDB _context;

    public EmployeeService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    } // done

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    } // done

    public async Task CreateEmployeeAsync(CreateEmployeeDto employeedto)
    {
        var employeecreate = new Employee()
        {
            EmployeeId = employeedto.EmployeeId,
            FirstName = employeedto.FirstName,
            LastName = employeedto.LastName,
            Email = employeedto.Email,
            Phone = employeedto.Phone,
            Address = employeedto.Address,
            Role = employeedto.Role,
            HireDate = employeedto.HireDate,
            Salary = employeedto.Salary,
        };

        await _context.Employees.AddAsync(employeecreate);
        await _context.SaveChangesAsync();
    } // done

    public async Task<bool> UpdateEmployeeAsync(int id, Employee updatedEmployee)
    {
        var existingEmployee = await _context.Employees.FindAsync(id);

        if (existingEmployee == null)
        {
            throw new Exception("Employee not found.");
            return false;
        }

        existingEmployee.FirstName = updatedEmployee.FirstName;
        existingEmployee.LastName = updatedEmployee.LastName;
        existingEmployee.Email = updatedEmployee.Email;
        existingEmployee.Phone = updatedEmployee.Phone;
        existingEmployee.Address = updatedEmployee.Address;
        existingEmployee.Role = updatedEmployee.Role;
        existingEmployee.HireDate = updatedEmployee.HireDate;
        existingEmployee.Salary = updatedEmployee.Salary;

            _context.Employees.Update(existingEmployee);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            throw new Exception("Employee not found.");
            return false;
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
}
