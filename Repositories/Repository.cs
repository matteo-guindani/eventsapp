using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EventsApp.Repositories
{
    public abstract class Repository<T>
    {
        protected readonly IMongoCollection<T> Collection;

        protected Repository(IMongoCollection<T> collection)
        {
            Collection = collection;
        }

        public T Find(string id)
        {
            return Collection
                .Find(Builders<T>.Filter.Eq("_id", new ObjectId(id)))
                .First();
        }

        public void Add(T entity)
        {
            Collection.InsertOne(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            Collection.InsertMany(entities);
        }

        public DeleteResult Truncate()
        {
            return Collection.DeleteMany("{}");
        }
    }
}
