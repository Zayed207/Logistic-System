namespace Domain.Entities
{

    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; }
        public string Role { get; set; } = string.Empty;

        public Client? Client { get; set; }
        public Driver? Driver { get; set; }
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}