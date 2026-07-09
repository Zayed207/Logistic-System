namespace Domain.Entities
{

    public class Vehicle : BaseEntity
    {
        public int VehicleId { get; set; }
        public string Lot { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Type { get; set; } = string.Empty;
        public short Status { get; set; }
        public bool Used { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public int CurrentMileage { get; set; }
        public decimal MaxWeight { get; set; }

        public ICollection<ShipmentAssignment> ShipmentAssignments { get; set; } = new List<ShipmentAssignment>();
    }
}