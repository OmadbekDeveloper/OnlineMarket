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
        public async Task<Responce<IEnumerable<ResultNotificationDto>>> GetNotifications()
        {
            var getall = await notificationService.GetAllNotificationsAsync();

            return getall;
        } // done

        [HttpGet("GetNotification")]
        public async Task<Responce<ResultNotificationDto>> GetNotification(int id)
        {
            var get = await notificationService.GetNotificationByIdAsync(id);

            return get;
        } // done

        [HttpPost("CreateNotification")]
        public async Task<Responce<ResultNotificationDto>> CreateNotification(CreateNotificationDto notificationdto)
        {
            var create = await notificationService.CreateNotificationAsync(notificationdto);

            return create;
        } // done

        [HttpPut("UpdateNotification")]
        public async Task<Responce<IEnumerable<ResultNotificationDto>>> UpdateNotification(UpdateNotificationDto updatedto)
        {
            var update = await notificationService.UpdateNotificationAsync(updatedto);

            return update;
        }

        [HttpDelete("DeleteNotification")]
        public async Task<Responce<bool>> DeleteNotification(int id)
        {
            var delete = await notificationService.DeleteNotificationAsync(id);

            return delete;
        }
    }
}