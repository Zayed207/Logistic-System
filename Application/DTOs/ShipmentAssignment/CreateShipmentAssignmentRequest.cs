using System;

namespace Application.DTOs.ShipmentAssignment
{
    public class CreateShipmentAssignmentRequest
    {
        public int ShipmentId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int AssignedByUserId { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public short Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
