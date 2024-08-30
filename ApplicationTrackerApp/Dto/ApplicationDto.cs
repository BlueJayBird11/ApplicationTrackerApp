﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Dto
{
    public class ApplicationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Company { get; set; }
        [Required]
        [StringLength(100)]
        public string Position { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        [Required]
        [StringLength(20)]
        public string MinPay { get; set; }
        [Required]
        [StringLength(20)]
        public string MaxPay { get; set; }
        [Url]
        public string LinkToCompanySite { get; set; }
        [Url]
        public string LinkToJobPost { get; set; }
        [Required]
        [StringLength(512)]
        public string Description { get; set; }
        [Required]
        public DateOnly DateApplied { get; set; }
        public DateOnly DateClosed { get; set; }
    }
}
