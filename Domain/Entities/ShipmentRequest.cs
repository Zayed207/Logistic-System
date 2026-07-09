namespace Domain.Entities
{

    public class ShipmentRequest : BaseEntity
    {
        public int ShipmentRequestId { get; set; }
        public string City { get; set; } = string.Empty;
        public int SenderClientId { get; set; }
        public int ReceiverClientId { get; set; }
        public short Status { get; set; }
        public string Notes { get; set; } = string.Empty;
        public short Priority { get; set; }
        public decimal TotalWeight { get; set; }

        public Client? Sender { get; set; }
        public Client? Receiver { get; set; }

        public Shipment? Shipment { get; set; }
        public ICollection<ShipmentPackage> Packages { get; set; } = new List<ShipmentPackage>();
    }
}