using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        // public string PasswordHash { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime MembershipExpirationDate { get; set; }
    }
}
