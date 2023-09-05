

using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos.Customer;
using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerservice)
        {
            this.customerService = customerservice;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await customerService.GetAllCustomersAsync();
            if (customers == null)
                return NotFound();

            return Ok(customers);
        } // done

        [HttpGet("GetCustomerId")]
        public async Task<IActionResult> GetCustomerId(int id)
        {
            var customer = await customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        } // done

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromForm] CreateCustomerDto customerDto)
        {
            await customerService.CreateCustomerAsync(customerDto);

            return Ok("Created");
        } // done

    }
}