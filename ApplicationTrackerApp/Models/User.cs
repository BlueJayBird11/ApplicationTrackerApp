using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [StringLength(512)]
        public required string PasswordHash { get; set; }
        [Required]
        public required DateTime SignUpDate { get; set; }
        public DateTime? MembershipExpirationDate { get; set; }
        public virtual ICollection<JobApplication>? Applications { get; set; }
    }
}
