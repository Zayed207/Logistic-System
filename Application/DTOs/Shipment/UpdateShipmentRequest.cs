using System;

namespace Application.DTOs.Shipment
{
    public class UpdateShipmentRequest
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
    }
}
