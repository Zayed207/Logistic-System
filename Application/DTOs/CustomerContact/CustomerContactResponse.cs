using System;

namespace Application.DTOs.CustomerContact
{
    public class CustomerContactResponse
    {
        public int CustomerContactId { get; set; }
        public int ClientId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
