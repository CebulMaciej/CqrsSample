using System;
using System.Collections.Generic;
using System.IO;
using CqrsSample.Infrastructure.Exceptions;
using CqrsSample.Infrastructure.Mongo.Abstract;
using CqrsSample.Infrastructure.Mongo.Documents;
using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Concrete
{
    internal class MongoCollectionProvider : IMongoCollectionProvider
    {
        private readonly IMongoDatabaseProvider _databaseProvider;
        
        public MongoCollectionProvider(IMongoDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
        
        public IMongoCollection<T> GetMongoDocumentCollection<T>() where T : IMongoDocument
        {
            Type type = typeof(T);
            string collectionName = TypeWithCollectionNameMapping[type];
            if (collectionName is null) throw new InvalidDataException("Unknown collection type");

            IMongoDatabase database = _databaseProvider.Get();
            if (database is null) throw new DatabaseNotFoundException();

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);
            if(collection is null) throw new DatabaseCollectionNotFoundException();

            return collection;
        }

        private static readonly Dictionary<Type,string> TypeWithCollectionNameMapping = new Dictionary<Type, string>
        {
            {typeof(ExampleDocument),"examples"}
        };
        
    }
}