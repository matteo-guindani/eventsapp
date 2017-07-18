using EventsApp.Models;
using MongoDB.Driver;

namespace EventsApp.Database
{
    public interface IDatabaseContext
    {
        IMongoCollection<Plan> Plans { get; }
    }
}
