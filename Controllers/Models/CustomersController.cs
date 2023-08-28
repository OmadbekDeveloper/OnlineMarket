using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos;

namespace OnlineMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("{GetAllCustomers}")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{GetCustomerId}")]
        public async Task<IActionResult> GetCustomerId(int id)
        {
            var customer = await customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost("{CreateCustomer}")]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCustomerDto customerDto)
        {
            await customerService.CreateCustomerAsync(customerDto);

            return Ok("Created");
        }

        // Implement POST, PUT, and DELETE methods similarly
    }
}