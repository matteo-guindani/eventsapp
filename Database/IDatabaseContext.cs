using EventsApp.Models;
using MongoDB.Driver;

namespace EventsApp.Database
{
    public interface IDatabaseContext
    {
        IMongoCollection<Event> Events { get; }
        IMongoCollection<Plan> Plans { get; }
    }
}
