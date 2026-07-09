using System;

namespace Application.DTOs.StateHistory
{
    public class CreateStateHistoryRequest
    {
        public int ShipmentId { get; set; }
        public short State { get; set; }
    }
}
