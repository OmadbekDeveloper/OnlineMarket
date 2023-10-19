namespace OnlineMarket.Models.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
      /*  public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }*/

    }
}
