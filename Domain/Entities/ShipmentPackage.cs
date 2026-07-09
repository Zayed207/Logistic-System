namespace Domain.Entities
{
    public class ShipmentPackage : BaseEntity
    {
        public int ShipmentPackageId { get; set; }
        public int ShipmentRequestId { get; set; }
        public decimal Volume { get; set; }
        public short Category { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; } = string.Empty;

        public ShipmentRequest? ShipmentRequest { get; set; }
    }
}