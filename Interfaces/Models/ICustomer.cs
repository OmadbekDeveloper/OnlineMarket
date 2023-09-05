// DONE
using OnlineMarket.Models.Dtos.Customer;

namespace OnlineMarket.Interfaces.Models
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task CreateCustomerAsync(CreateCustomerDto customerdto);
        Task<bool> UpdateCustomerAsync(int id, Customer updatedCustomer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
