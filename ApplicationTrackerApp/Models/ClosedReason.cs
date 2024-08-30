using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Models
{
    public class ClosedReason
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        public virtual ICollection<JobApplication> Applications { get; set; }
    }
}
