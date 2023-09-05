
using OnlineMarket.Models.Dtos.Notification;

public class NotificationService : INotificationService
{
    private readonly OnlineMarketDB _context;

    public NotificationService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Notification>> GetAllNotificationsAsync()
    {
        return await _context.Notifications.ToListAsync();
    } // done

    public async Task<Notification> GetNotificationByIdAsync(int id)
    {
        return await _context.Notifications.FindAsync(id);
        
    } // done

    public async Task CreateNotificationAsync(CreateNotificationDto notificationdto)
    {
        var notificationrcreate = new Notification()
        {
            NotificationId = notificationdto.NotificationId,
            UserId = notificationdto.UserId,
            Message = notificationdto.Message,
            Timestamp = notificationdto.Timestamp,
            IsRead = notificationdto.IsRead,
        };

        await _context.Notifications.AddAsync(notificationrcreate);
        await _context.SaveChangesAsync();
    } // done

    public async Task<bool> UpdateNotificationAsync(int id, Notification updatedNotification)
    {
        var existingNotification = await _context.Notifications.FindAsync(id);

        if (existingNotification == null)
        {
            throw new Exception("Notification not found.");
            return false;
        }

        existingNotification.Message = updatedNotification.Message;
        existingNotification.Timestamp = updatedNotification.Timestamp;
        existingNotification.IsRead = updatedNotification.IsRead;

        _context.Notifications.Update(existingNotification);
        await _context.SaveChangesAsync();
        return false;
    }

    public async Task<bool> DeleteNotificationAsync(int id)
    {
        var notification = await _context.Notifications.FindAsync(id);

        if (notification == null)
        {
            throw new Exception("Notification not found.");
            return false;
        }

        _context.Notifications.Remove(notification);
        await _context.SaveChangesAsync();
        return true;
    }
}
