using ApiTest.Models.Entities;
using MongoDB.Driver;

namespace ApiTest.DbConnectors
{
    public class MongoDbConnector
    {
        public IMongoCollection<User> UsersCollection;
        public MongoDbConnector(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("mongo"));
            var db = client.GetDatabase(config.GetSection("mongo_databases").GetValue<string>("mongo_apitest"));
            UsersCollection = db.GetCollection<User>(config.GetSection("mongo_collections").GetValue<string>("mongo_apitest_users"));
        }
    }
}
