using System;
using System.Threading.Tasks;
using CqrsSample.Application.Services;
using CqrsSample.Core.Entities;
using CqrsSample.Infrastructure.Mongo.Abstract;
using CqrsSample.Infrastructure.Mongo.Documents;
using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Concrete
{
    internal class MongoExampleRepository : IExampleRepository
    {
        private readonly IMongoCollectionProvider _collectionProvider;

        public MongoExampleRepository(IMongoCollectionProvider collectionProvider)
        {
            _collectionProvider = collectionProvider;
        }

        public async Task<Example> GetExample(Guid id)
        {
            IMongoCollection<ExampleDocument> collection = GetCollection();

            ExampleDocument document = await collection.Find(doc => doc.Id == id).FirstOrDefaultAsync();

            return document is null ? null : new Example(document.Id,document.Content);
        }

        public async  Task Add(Example example)
        {
            IMongoCollection<ExampleDocument> collection = GetCollection();
            
            await collection.InsertOneAsync(new ExampleDocument
            {
                Id = example.Id,
                Content = example.Content
            });
        }

        private IMongoCollection<ExampleDocument> GetCollection() => _collectionProvider.GetMongoDocumentCollection<ExampleDocument>();
    }
}