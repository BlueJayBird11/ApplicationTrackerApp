namespace ApplicationTrackerApp.Models
{
    public class JobType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
