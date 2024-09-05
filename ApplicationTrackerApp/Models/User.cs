using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [StringLength(512)]
        public string PasswordHash { get; set; }
        public DateTime? MembershipExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<JobApplication>? Applications { get; set; }
        public virtual Login Login { get; set; }

        public User()
        {
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
        }
    }
}
