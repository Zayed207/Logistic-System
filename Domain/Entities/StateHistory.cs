namespace Domain.Entities
{
    public class StateHistory : BaseEntity
    {
        public int StateHistoryId { get; set; }
        public int ShipmentId { get; set; }
        public short State { get; set; }

        public Shipment? Shipment { get; set; }
    }
}