using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos;
using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingInfosController : ControllerBase
    {
        private readonly IShippingInfoService shippingInfoService;

        public ShippingInfosController(IShippingInfoService shippingInfoService)
        {
            this.shippingInfoService = shippingInfoService;
        }

        [HttpGet("GetShippingInfos")]
        public async Task<IActionResult> GetShippingInfos()
        {
            var shippingInfos = await shippingInfoService.GetShippingInfoByOrderAsync();
            if (shippingInfos == null)
                return NotFound();

            return Ok(shippingInfos);
        } // done

        [HttpGet("GetShippingInfo")]
        public async Task<IActionResult> GetShippingInfo(int id)
        {
            var shippingInfo = await shippingInfoService.GetShippingInfoByOrderIdAsync(id);
            if (shippingInfo == null)
                return NotFound();

            return Ok(shippingInfo);
        }  // done

        [HttpPost("CreateShippingInfo")]
        public async Task<IActionResult> CreateShippingInfo(CreateShippingInfoDto createShippingInfoDto)
        {
            await shippingInfoService.CreateShippingInfoAsync(createShippingInfoDto);
            if (createShippingInfoDto == null)
            {
                return NotFound();
            }

            return Ok("Added");
        }  // orderid not

        // Implement POST, PUT, and DELETE methods similarly
    }
}