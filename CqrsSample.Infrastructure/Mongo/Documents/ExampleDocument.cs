using System;

namespace CqrsSample.Infrastructure.Mongo.Documents
{
    public class ExampleDocument : IMongoDocument
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}