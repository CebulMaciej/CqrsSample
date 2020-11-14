using CqrsSample.Infrastructure.Mongo.Documents;
using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Abstract
{
    internal interface IMongoCollectionProvider
    {
        IMongoCollection<T> GetMongoDocumentCollection<T>() where T : IMongoDocument;
    }
}