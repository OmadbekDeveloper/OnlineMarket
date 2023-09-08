// DONE
using OnlineMarket.Models.Dtos.Customer;

namespace OnlineMarket.Interfaces.Models
{
    public interface ICustomerService
    {
        Task<Responce<IEnumerable<ResultCustomerDto>>> GetAllCustomersAsync();
        Task<Responce<ResultCustomerDto>> GetCustomerByIdAsync(int id);
        Task<Responce<ResultCustomerDto>> CreateCustomerAsync(CreateCustomerDto customerdto);
        Task<Responce<IEnumerable<ResultCustomerDto>>> UpdateCustomerAsync(UpdateCustomerDto updatedCustomer);
        Task<Responce<bool>> DeleteCustomerAsync(int id);
    }
}
