﻿// DONE
using OnlineMarket.Models.Dtos;

namespace OnlineMarket.Interfaces.Models
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        public Task CreateCustomerAsync(CreateCustomerDto customerdto);
        Task<bool> UpdateCustomerAsync(int id, Customer updatedCustomer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
