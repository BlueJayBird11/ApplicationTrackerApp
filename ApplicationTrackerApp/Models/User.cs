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
        [Required]
        public bool IsEmailConfirmed { get; set; }
        public DateTime MembershipDate { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
