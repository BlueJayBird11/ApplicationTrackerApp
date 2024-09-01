using ApplicationTrackerApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ApplicationTrackerApp.Dto
{
    public class JobApplicationDto
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string MinPay { get; set; }
        public string MaxPay { get; set; }
        public string LinkToCompanySite { get; set; }
        public string LinkToJobPost { get; set; }
        public string Description { get; set; }
        public DateOnly DateApplied { get; set; }
        public DateOnly DateClosed { get; set; }
    }
}
