namespace Domain.Entities
{


    public class CustomerContact : BaseEntity
    {
        public int CustomerContactId { get; set; }
        public int ClientId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public Client? Client { get; set; }
    }
}
