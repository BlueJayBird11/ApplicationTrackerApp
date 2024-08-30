using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(256)]
        public string PasswordHash { get; set; }
        [Required]
        public DateTime SignUpDate { get; set; }
        public DateTime MembershipExpirationDate { get; set; }
        public virtual ICollection<JobApplication> Applications { get; set; }
    }
}
