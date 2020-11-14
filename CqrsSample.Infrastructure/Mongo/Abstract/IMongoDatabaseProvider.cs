using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Abstract
{
    internal interface IMongoDatabaseProvider
    {
        IMongoDatabase Get();
    }
}