using System;

namespace EventsApp.Models
{
    public class EventMetadata
    {
        public string Type { get; set; }
        public DateTime CreatedAt { get; }

        public EventMetadata()
        {
            CreatedAt = new DateTime();
        }

        public EventMetadata(string type)
        {
            Type = type;
            CreatedAt = new DateTime();
        }
    }
}
