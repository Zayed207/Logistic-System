using System;

namespace Application.DTOs.User
{
    public class CreateUserRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
