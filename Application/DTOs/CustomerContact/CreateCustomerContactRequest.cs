using System;

namespace Application.DTOs.CustomerContact
{
    public class CreateCustomerContactRequest
    {
        public int ClientId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
