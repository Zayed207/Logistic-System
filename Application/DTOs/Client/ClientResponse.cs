using System;

namespace Application.DTOs.Client
{
    public class ClientResponse
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
