// DONE
using OnlineMarket.Models.Dtos.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(OnlineMarketDB context)
    {
        this._unitOfWork = new UnitOfWork(context);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            ));
    }

    public async Task<Responce<IEnumerable<ResultEmployeeDto>>> GetAllEmployeesAsync()
    {
        try
        {
            var getAllEmployee = await _unitOfWork.EmployeeRepository.GetAllAsync();

            if (getAllEmployee == null)
            {
                return new Responce<IEnumerable<ResultEmployeeDto>>
                {
                    StatusCode = 404,
                    Message = "Not found",
                    Data = null
                };
            }

            var mapper = _mapper.Map<IEnumerable<ResultEmployeeDto>>(getAllEmployee);

            return new Responce<IEnumerable<ResultEmployeeDto>>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = mapper
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultEmployeeDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultEmployeeDto>> GetEmployeeByIdAsync(int id)
    {
        try
        {
            var getEmployeeById = _unitOfWork.EmployeeRepository.Get(x => x.EmployeeId == id);

            if (getEmployeeById == null)
            {
                return new Responce<ResultEmployeeDto>
                {
                    StatusCode = 404,
                    Message = "Not Found",

                };
            }

            var map = _mapper.Map<ResultEmployeeDto>(getEmployeeById);

            return new Responce<ResultEmployeeDto>
            {
                StatusCode = 200,
                Message = "all taken out",
                Data = map,
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultEmployeeDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultEmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto employeedto)
    {
        try
        {
            var emmployeecreate = new Employee()
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

            _unitOfWork.EmployeeRepository.Add(emmployeecreate);
            await _unitOfWork.EmployeeRepository.SaveAsync();

            return new Responce<ResultEmployeeDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultEmployeeDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<IEnumerable<ResultEmployeeDto>>> UpdateEmployeeAsync(UpdateEmployeeDto updatedto)
    {
        try
        {
            var existingEmployee = _unitOfWork.EmployeeRepository.Get(x => x.EmployeeId == updatedto.EmployeeId);

            if (existingEmployee == null)
            {
                return new Responce<IEnumerable<ResultEmployeeDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var map = _mapper.Map(updatedto, existingEmployee);

            _unitOfWork.EmployeeRepository.Update(map);
            await _unitOfWork.EmployeeRepository.SaveAsync();

            return new Responce<IEnumerable<ResultEmployeeDto>>
            {
                StatusCode = 200,
                Message = "Mahsulot yangilandi",
                Data = null
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultEmployeeDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    }

    public async Task<Responce<bool>> DeleteEmployeeAsync(int id)
    {
        try
        {
            var deleteemployee = _unitOfWork.EmployeeRepository.Get(x => x.EmployeeId == id);

            if (deleteemployee == null)
            {
                return new Responce<bool>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = false
                };
            }

            _unitOfWork.EmployeeRepository.Remove(deleteemployee);
            await _unitOfWork.EmployeeRepository.SaveAsync();

            return new Responce<bool>
            {
                StatusCode = 200,
                Message = "Product deleted successfully",
                Data = true
            };
        }
        catch (Exception ex)
        {
            return new Responce<bool>
            {
                StatusCode = 500,
                Message = "Error",
                Data = false
            };
        }
    }
}
