using System.Collections.Generic;
using System;
using EventsApp.Database;
using EventsApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EventsApp.Repositories
{
    public class EventRepository : Repository<Event>
    {
        public EventRepository(IDatabaseContext context) : base(context.Events)
        {
        }

        public IList<EventTypeCount> CountByType(string excludedType)
        {
            var aggregate = Collection.Aggregate();
            if (!String.IsNullOrEmpty(excludedType))
            {
                aggregate = aggregate.Match(Builders<Event>.Filter.Ne("Metadata.Type", excludedType));
            }

            return aggregate
                .Group<EventTypeCount>(new BsonDocument {{"_id", "$Metadata.Type"}, {"Count", new BsonDocument("$sum", 1)}})
                .ToList();
        }
    }
}
