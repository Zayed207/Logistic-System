using System;

namespace Application.DTOs.Driver
{
    public class DriverResponse
    {
        public int DriverId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string LicenseId { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public bool Active { get; set; }
        public short Status { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
