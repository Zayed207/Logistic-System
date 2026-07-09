using System;

namespace Application.DTOs.Client
{
    public class CreateClientRequest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
