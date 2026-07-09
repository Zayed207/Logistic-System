using System;

namespace Application.DTOs.Vehicle
{
    public class UpdateVehicleRequest
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
    }
}
