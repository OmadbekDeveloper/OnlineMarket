﻿//  DONE
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
    }

    public async Task<Notification> GetNotificationByIdAsync(int id)
    {
        return await _context.Notifications.FindAsync(id);
    }

    public async Task<Notification> CreateNotificationAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();

        return notification;
    }

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
