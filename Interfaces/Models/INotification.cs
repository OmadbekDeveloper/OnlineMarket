namespace OnlineMarket.Interfaces.Models
{
    public interface INotificationService
    {
        Task<List<Notification>> GetAllNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(int id);
        Task CreateNotificationAsync(CreateNotificationDto notificationdto);
        Task<bool> UpdateNotificationAsync(int id, Notification updatedNotification);
        Task<bool> DeleteNotificationAsync(int id);
        // Add more methods as needed
    }
}
