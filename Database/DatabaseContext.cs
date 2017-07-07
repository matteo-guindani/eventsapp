using System;
using EventsApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EventsApp.Database
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMongoDatabase _database;

        public DatabaseContext(IOptions<DatabaseConfiguration> config)
        {
            try
            {
                var client = new MongoClient(GetSettings(config));
                _database = client.GetDatabase(config.Value.DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to access the MongoDB server.", ex);
            }
        }

        public IMongoCollection<Event> Events => _database.GetCollection<Event>("events");
        public IMongoCollection<Plan> Plans => _database.GetCollection<Plan>("plans");

        private MongoClientSettings GetSettings(IOptions<DatabaseConfiguration> config)
        {
            var settings = MongoClientSettings.FromUrl(
                new MongoUrl(config.Value.ConnectionString)
            );

            if (config.Value.IsSsl)
            {
                settings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            return settings;
        }
    }
}
