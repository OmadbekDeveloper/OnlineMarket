using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingInfosController : ControllerBase
    {
        private readonly OnlineMarketDB _context;

        public ShippingInfosController(OnlineMarketDB context)
        {
            _context = context;
        }

        [HttpGet("GetShippingInfos")]
        public async Task<IActionResult> GetShippingInfos()
        {
            var shippingInfos = await _context.ShippingInfos.ToListAsync();
            if (shippingInfos == null)
                return NotFound();

            return Ok(shippingInfos);
        } // done

        [HttpGet("GetShippingInfo")]
        public async Task<IActionResult> GetShippingInfo(int id)
        {
            var shippingInfo = await _context.ShippingInfos.FindAsync(id);
            if (shippingInfo == null)
                return NotFound();

            return Ok(shippingInfo);
        }  // done

        // Implement POST, PUT, and DELETE methods similarly
    }
}