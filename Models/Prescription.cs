using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventsApp.Models
{
    public class Prescription
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Product { get; set; }

        public double Quantity { get; set; }

        public int Frequency { get; set; }

        public int Duration { get; set; }

        public double TotalQuantity => Quantity * Frequency * Duration;

        public Prescription()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
