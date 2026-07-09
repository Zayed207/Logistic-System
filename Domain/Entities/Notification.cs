namespace Domain.Entities
{

    public class Notification : BaseEntity
    {
        public int NotificationId { get; set; }
        public int ShipmentId { get; set; }
        public int RecipientId { get; set; }
        public string Message { get; set; } = string.Empty;

        public Shipment? Shipment { get; set; }
        public User? Recipient { get; set; }
    }
}