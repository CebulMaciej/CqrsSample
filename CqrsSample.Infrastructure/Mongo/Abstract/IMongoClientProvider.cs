using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Abstract
{
    internal interface IMongoClientProvider
    {
        MongoClient Create();
    }
}