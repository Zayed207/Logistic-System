
using System.Collections.Generic;

namespace Domain.Entities {

    public class Client : BaseEntity
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public User? User { get; set; }
        public ICollection<CustomerContact> CustomerContacts { get; set; } = new List<CustomerContact>();
        public ICollection<ShipmentRequest> SentRequests { get; set; } = new List<ShipmentRequest>();
        public ICollection<ShipmentRequest> ReceivedRequests { get; set; } = new List<ShipmentRequest>();
    }
}