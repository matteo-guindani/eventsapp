using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventsApp.Models
{
    public class Plan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RecipientId { get; set; }
        public string DoctorId { get; set; }
        public DateTime StartingDate { get; set; }
        public IList<Prescription> Prescriptions { get; set; }

        public Plan()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Prescriptions = new List<Prescription>();
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
