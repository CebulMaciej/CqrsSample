using System;
using CqrsSample.Infrastructure.Exceptions;
using CqrsSample.Infrastructure.Mongo.Abstract;
using CqrsSample.Infrastructure.Options;
using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Concrete
{
    internal class MongoDatabaseProvider : IMongoDatabaseProvider
    {
        private readonly MongoOptions _options;
        private readonly IMongoClientProvider _mongoClientProvider;

        public MongoDatabaseProvider(IMongoClientProvider mongoClientProvider, MongoOptions options)
        {
            _mongoClientProvider = mongoClientProvider;
            _options = options;
        }

        public IMongoDatabase Get()
        {
            MongoClient mongoClient = _mongoClientProvider.Create();
            
            if(mongoClient is null) throw new MongoClientCreationException();

            return mongoClient.GetDatabase(_options.Database);
        }
    }
}