namespace ApplicationTrackerApp.Models
{
    public class ClosedReason
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
