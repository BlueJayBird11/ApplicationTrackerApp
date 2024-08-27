namespace ApplicationTrackerApp.Models
{
    public class Application
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
        public bool IsClosed { get; set; }
        public string DateApplied { get; set; }
        public string DateClosed { get; set; }
        public User User { get; set; }
        public JobType JobType { get; set; }
        public ClosedReason ClosedReason { get; set; }
    }
}
