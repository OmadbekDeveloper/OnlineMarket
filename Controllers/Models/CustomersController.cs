using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos.Customer;
using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerservice)
        {
            customerService = customerservice;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<Responce<IEnumerable<ResultCustomerDto>>> GetAllCustomers()
        {
            var customers = await customerService.GetAllCustomersAsync();

            return customers;
        } // done

        [HttpGet("GetCustomerId")]
        public async Task<Responce<ResultCustomerDto>> GetCustomerId(int id)
        {
            var customer = await customerService.GetCustomerByIdAsync(id);

            return customer;
        } // done

        [HttpPost("CreateCustomer")]
        public async Task<Responce<ResultCustomerDto>> CreateCustomer(CreateCustomerDto customerDto)
        {
            var createcustomer = await customerService.CreateCustomerAsync(customerDto);

            return createcustomer;
        } // done

        [HttpPut("UpdateCustomer")]
        public async Task<Responce<IEnumerable<ResultCustomerDto>>> UpdateCustomer(UpdateCustomerDto customerDto)
        {
            var updatecustomer = await customerService.UpdateCustomerAsync(customerDto);

            return updatecustomer;
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<Responce<bool>> DeleteCustomer(int id)
        {
            var deletecustomer = await customerService.DeleteCustomerAsync(id);

            return deletecustomer;
        }

    }
}