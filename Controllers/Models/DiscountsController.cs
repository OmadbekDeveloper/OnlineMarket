using OnlineMarket.Models.Dtos;
using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService discountService;

        public DiscountsController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        [HttpGet("GetDiscounts")]
        public async Task<IActionResult> GetDiscounts()
        {
            var discounts = await discountService.GetAllDiscountsAsync();
            if (discounts == null)
                return NotFound();

            return Ok(discounts);
        } // done

        [HttpGet("GetDiscount")]
        public async Task<IActionResult> GetDiscount(int id)
        {
            var discount = await discountService.GetDiscountByIdAsync(id);
            if (discount == null)
                return NotFound();

            return Ok(discount);
        } // done

        [HttpPost("CreateDiscount")]

        public async Task<IActionResult> CreateDiscount(CreateDiscountDto discountdto)
        {
            await discountService.CreateDiscountAsync(discountdto);

            return Ok("Created");
        } // done

    }
}