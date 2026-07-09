using System;

namespace Application.DTOs.StateHistory
{
    public class StateHistoryResponse
    {
        public int StateHistoryId { get; set; }
        public int ShipmentId { get; set; }
        public short State { get; set; }
    }
}
