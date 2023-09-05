using OnlineMarket.Models.Dtos.Payment;
using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet("{GetPayments}")]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await paymentService.GetAllPaymentsAsync();
            if (payments == null)
                return NotFound();

            return Ok(payments);
        } // done

        [HttpGet("{GetPayment}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var payment = await paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        } // done

        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            await paymentService.CreatePaymentAsync(createPaymentDto);

            return Ok("Created");
        }

    }
}