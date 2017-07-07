using MongoDB.Bson;

namespace EventsApp.Models
{
    public class Event
    {
        public ObjectId Id { get; set; }
        public EventMetadata Metadata { get; set; }

        public Event()
        {
            Id = ObjectId.GenerateNewId();
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
