using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos.Discount;
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
        public async Task<Responce<IEnumerable<ResultDiscountDto>>> GetAllDiscounts()
        {
            var discounts = await discountService.GetAllDiscountsAsync();

            return discounts;
        } // done

        [HttpGet("GetDiscount")]
        public async Task<Responce<ResultDiscountDto>> GetDiscountId(int id)
        {
            var discount = await discountService.GetDiscountByIdAsync(id);

            return discount;
        } // done

        [HttpPost("CreateDiscount")]

        public async Task<Responce<ResultDiscountDto>> CreateDiscoont(CreateDiscountDto discountDto)
        {
            var creatediscount = await discountService.CreateDiscountAsync(discountDto);

            return creatediscount;
        } // done

        [HttpPut("UpdateDiscount")]
        public async Task<Responce<IEnumerable<ResultDiscountDto>>> UpdateDiscount(UpdateDiscountDto discountDto)
        {
            var updatediscounnt = await discountService.UpdateDiscountAsync(discountDto);

            return updatediscounnt;
        }

        [HttpDelete("DeleteDiscount")]
        public async Task<Responce<bool>> DeleteDiscount(int id)
        {
            var deletecustomer = await discountService.DeleteDiscountAsync(id);

            return deletecustomer;
        }
    }
}