using MongoDB.Driver;

namespace FlightCrm.DAL.Repositories
{
    internal abstract class MongoRepository
    {
        protected IMongoClient Client { get; private set;}
        protected IMongoDatabase Database { get; private set; }

        protected MongoRepository()
        {
            Client  = new MongoClient("mongodb://127.0.0.1:27017");
            Database = Client.GetDatabase("FlightCrm");
        }
    }
}