using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Models.Dtos.Notification;
using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpGet("GetNotifications")]
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await notificationService.GetAllNotificationsAsync();
            if (notifications == null)
                return NotFound();

            return Ok(notifications);
        } // done

        [HttpGet("GetNotification")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var notification = await notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
                return NotFound();

            return Ok(notification);
        } // done

        [HttpPost("CreateNotification")]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto notificationdto)
        {
            await notificationService.CreateNotificationAsync(notificationdto);

            return Ok("Created");
        } // done
    }
}