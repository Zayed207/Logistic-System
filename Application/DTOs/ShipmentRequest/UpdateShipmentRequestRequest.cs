using System;

namespace Application.DTOs.ShipmentRequest
{
    public class UpdateShipmentRequestRequest
    {
        public int ShipmentRequestId { get; set; }
        public string City { get; set; } = string.Empty;
        public int SenderClientId { get; set; }
        public int ReceiverClientId { get; set; }
        public short Status { get; set; }
        public string Notes { get; set; } = string.Empty;
        public short Priority { get; set; }
        public decimal TotalWeight { get; set; }
    }
}
