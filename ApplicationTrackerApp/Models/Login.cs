using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [StringLength(128)]
        public string SessionKey { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public virtual User User { get; set; }

        public Login()
        {
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
        }
    }
}
