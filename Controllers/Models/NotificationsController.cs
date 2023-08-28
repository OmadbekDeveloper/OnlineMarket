namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly OnlineMarketDB _context;

        public NotificationsController(OnlineMarketDB context)
        {
            _context = context;
        }

        [HttpGet("{GetNotifications}")]
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await _context.Notifications.ToListAsync();
            return Ok(notifications);
        }

        [HttpGet("{GetNotification}")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
                return NotFound();

            return Ok(notification);
        }
    }
}