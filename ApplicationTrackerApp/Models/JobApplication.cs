﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public required string Company { get; set; }
        [Required]
        [StringLength(100)]
        public required string Position { get; set; }
        [Required]
        [StringLength(100)]
        public required string Location { get; set; }
        [Required]
        [StringLength(20)]
        public required string MinPay { get; set; }
        [Required]
        [StringLength(20)]
        public required string MaxPay { get; set; }
        [Url]
        public string? LinkToCompanySite { get; set; }
        [Url]
        public string? LinkToJobPost { get; set; }
        [Required]
        [StringLength(512)]
        public required string Description { get; set; }
        [Required]
        public DateOnly DateApplied { get; set; }
        public DateOnly DateClosed { get; set; }
        public virtual User? User { get; set; }
        [Required]
        public required virtual JobType JobType { get; set; }
        public virtual ClosedReason? ClosedReason { get; set; }
    }
}