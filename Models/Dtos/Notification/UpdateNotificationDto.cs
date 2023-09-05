namespace OnlineMarket.Models.Dtos.Notification
{
    public class UpdateNotificationDto
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
    }
}
