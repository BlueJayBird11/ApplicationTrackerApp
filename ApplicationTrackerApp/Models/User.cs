namespace ApplicationTrackerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime SignUpDate { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool HasPremium { get; set; }
        public DateTime MembershipDate { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
