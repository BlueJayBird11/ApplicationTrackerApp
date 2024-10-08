﻿using ApplicationTrackerApp.Controllers;
using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Models
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public required string Name { get; set; }
        public virtual ICollection<JobApplication>? Applications { get; set; }
    }
}
