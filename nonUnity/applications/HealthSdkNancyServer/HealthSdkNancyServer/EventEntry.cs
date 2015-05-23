namespace HealthSdkNancyServer
{
    internal class EventEntry
    {
        public int ApplicationId { get; set; }
        public int EventId { get; set; }
        public bool Seen { get; set; }
    }
}