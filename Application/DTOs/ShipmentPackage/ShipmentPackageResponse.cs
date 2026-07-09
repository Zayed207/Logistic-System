using System;

namespace Application.DTOs.ShipmentPackage
{
    public class ShipmentPackageResponse
    {
        public int ShipmentPackageId { get; set; }
        public int ShipmentRequestId { get; set; }
        public decimal Volume { get; set; }
        public short Category { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
