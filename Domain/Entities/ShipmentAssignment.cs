namespace Domain.Entities
{

    public class ShipmentAssignment : BaseEntity
    {
        public int ShipmentAssignmentId { get; set; }
        public int ShipmentId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int AssignedByUserId { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public short Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public Shipment? Shipment { get; set; }
        public Driver? Driver { get; set; }
        public Vehicle? Vehicle { get; set; }
        public User? AssignedByUser { get; set; }
    }
}