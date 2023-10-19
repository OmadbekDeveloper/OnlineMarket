using OnlineMarket.Models.Dtos.Notification;

namespace OnlineMarket.Interfaces.Models
{
    public interface INotificationService
    {
        Task<Responce<IEnumerable<ResultNotificationDto>>> GetAllNotificationsAsync();
        Task<Responce<ResultNotificationDto>> GetNotificationByIdAsync(int id);
        Task<Responce<ResultNotificationDto>> CreateNotificationAsync(CreateNotificationDto notificationdto);
        Task<Responce<IEnumerable<ResultNotificationDto>>> UpdateNotificationAsync(UpdateNotificationDto updatedto);
        Task<Responce<bool>> DeleteNotificationAsync(int id);
    }
}
