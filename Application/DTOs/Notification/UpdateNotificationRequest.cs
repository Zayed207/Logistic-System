using System;

namespace Application.DTOs.Notification
{
    public class UpdateNotificationRequest
    {
        public int NotificationId { get; set; }
        public int ShipmentId { get; set; }
        public int RecipientId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
