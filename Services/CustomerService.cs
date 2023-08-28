// DONE
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Models.Dtos;

public class CustomerService : ICustomerService
{
    private readonly OnlineMarketDB _context;

    public CustomerService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    //public async Task<Customer> CreateCustomerAsync(Customer createcustomer)
    //{
    //    var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == createcustomer.Email);

    //    if (customer != null)
    //    {
    //        throw new Exception("Customer with the same email already exists.");
    //    }

    //    await _context.Customers.AddAsync(customer);
    //    await _context.SaveChangesAsync();

    //    return customer;
    //}

    public async Task CreateCustomerAsync(CreateCustomerDto customerdto)
    {
        var customercreate = new Customer()
        {
            CustomerId = customerdto.CustomerId,
            FirstName = customerdto.FirstName,
            LastName = customerdto.LastName,
            Email = customerdto.Email,
            Phone = customerdto.Phone,
            Address = customerdto.Address,
        };

        await _context.Customers.AddAsync(customercreate);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateCustomerAsync(int id, Customer updatedCustomer)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            throw new Exception("Customer not found.");
            return false;
        }

        customer.FirstName = updatedCustomer.FirstName;
        customer.LastName = updatedCustomer.LastName;
        customer.Email = updatedCustomer.Email;
        customer.Phone = updatedCustomer.Phone;
        customer.Address = updatedCustomer.Address;

        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            throw new Exception("Customer not found.");
            return false;
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
}
