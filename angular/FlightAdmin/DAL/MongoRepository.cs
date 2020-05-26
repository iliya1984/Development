using MongoDB.Driver;

namespace FlightAdmin.DAL
{
    public abstract class MongoRepository
    {
        protected MongoClient Client { get; private set; }
        protected IMongoDatabase Database {get; private set; }

        protected MongoRepository(string databaseName)
        {
            string connectionString = "mongodb://ubdev02:32017";
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(databaseName);
        }
    }
}