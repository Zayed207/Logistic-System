namespace Domain.Entities
{
    public class ProofDocument : BaseEntity
    {
        public int ProofDocumentId { get; set; }
        public int ShipmentId { get; set; }
        public short Type { get; set; }
        public byte? Status { get; set; }
        public string Photo { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }

        public Shipment? Shipment { get; set; }
    }
}