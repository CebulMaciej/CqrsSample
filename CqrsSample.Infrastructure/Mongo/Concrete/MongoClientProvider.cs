using CqrsSample.Infrastructure.Mongo.Abstract;
using CqrsSample.Infrastructure.Options;
using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Concrete
{
    public class MongoClientProvider : IMongoClientProvider
    {
        private readonly MongoOptions _mongoOptions;

        public MongoClientProvider(MongoOptions mongoOptions)
        {
            _mongoOptions = mongoOptions;
        }

        public MongoClient Create() => new MongoClient(_mongoOptions.Address);
        
    }
}