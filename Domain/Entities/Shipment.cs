namespace Domain.Entities
{

    public class Shipment : BaseEntity
    {
        public int ShipmentId { get; set; }
        public int ShipmentRequestId { get; set; }
        public DateTime Date { get; set; }
        public short CurrentState { get; set; }
        public bool Ordered { get; set; }
        public DateTime? ArrivedAt { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public decimal Fees { get; set; }

        public ShipmentRequest? ShipmentRequest { get; set; }

        public ICollection<ShipmentAssignment> ShipmentAssignments { get; set; } = new List<ShipmentAssignment>();
        public ICollection<StateHistory> StateHistories { get; set; } = new List<StateHistory>();
        public ICollection<ProofDocument> ProofDocuments { get; set; } = new List<ProofDocument>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}