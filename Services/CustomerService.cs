
public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(OnlineMarketDB context)
    {
        this._unitOfWork = new UnitOfWork(context);

        this._mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>()
            ));
    }

    public async Task<Responce<IEnumerable<ResultCustomerDto>>> GetAllCustomersAsync()
    {
        try
        {
            var getAllCustomers = await _unitOfWork.CustomerRepository.GetAllAsync();

            if (getAllCustomers == null)
            {
                return new Responce<IEnumerable<ResultCustomerDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = null
                };
            }

            var mapper = _mapper.Map<IEnumerable<ResultCustomerDto>>(getAllCustomers);

            return new Responce<IEnumerable<ResultCustomerDto>>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = mapper
            };
        }
        catch (Exception ex)
        {
            return new Responce<IEnumerable<ResultCustomerDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultCustomerDto>> GetCustomerByIdAsync(int id)
    {
        try
        {
            var getCustomerById = _unitOfWork.CustomerRepository.Get(x => x.CustomerId == id);


            if (getCustomerById == null)
            {
                return new Responce<ResultCustomerDto>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var map = _mapper.Map<ResultCustomerDto>(getCustomerById);

            return new Responce<ResultCustomerDto>
            {
                StatusCode = 200,
                Message = "All products received",
                Data = map
            };
        }
        catch (Exception ex)
        {
            return new Responce<ResultCustomerDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<ResultCustomerDto>> CreateCustomerAsync(CreateCustomerDto customerdto)
    {
        try
        {
            var customercreate = new Customer()
            {
                CustomerId = customerdto.CustomerId,
                FirstName = customerdto.FirstName,
                LastName = customerdto.LastName,
                Password = customerdto.Password,
                Email = customerdto.Email,
                Phone = customerdto.Phone,
                Address = customerdto.Address,
            };

            _unitOfWork.CustomerRepository.Add(customercreate);
            await _unitOfWork.CustomerRepository.SaveAsync();

            return new Responce<ResultCustomerDto>
            {
                StatusCode = 200,
                Message = "Mahsulot muvaffaqiyatli yaratildi",
                Data = null
            };
        }
        catch(Exception ex)
        {
            return new Responce<ResultCustomerDto>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<IEnumerable<ResultCustomerDto>>> UpdateCustomerAsync(UpdateCustomerDto updatedCustomer)
    {
        try
        {
            var existingCustomer = _unitOfWork.CustomerRepository.Get(x => x.CustomerId == updatedCustomer.CustomerId);

            if (existingCustomer == null)
            {
                return new Responce<IEnumerable<ResultCustomerDto>>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                };
            }

            var map = _mapper.Map(updatedCustomer, existingCustomer);

            _unitOfWork.CustomerRepository.Update(map);
            await _unitOfWork.CustomerRepository.SaveAsync();

            return new Responce<IEnumerable<ResultCustomerDto>>
            {
                StatusCode = 200,
                Message = "Mahsulot yangilandi",
                Data = null
            };
        }
        catch(Exception ex)
        {
            return new Responce<IEnumerable<ResultCustomerDto>>
            {
                StatusCode = 500,
                Message = "Error",
                Data = null
            };
        }
    } // done

    public async Task<Responce<bool>> DeleteCustomerAsync(int id)
    {
        try
        {
            var deletecustomer = _unitOfWork.CustomerRepository.Get(x => x.CustomerId == id);

            if (deletecustomer == null)
            {
                return new Responce<bool>
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Data = false
                };
            }

            _unitOfWork.CustomerRepository.Remove(deletecustomer);
            await _unitOfWork.CustomerRepository.SaveAsync();

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
    } // done
}
