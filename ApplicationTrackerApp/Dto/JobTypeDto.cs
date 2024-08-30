using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Dto
{
    public class JobTypeDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}
